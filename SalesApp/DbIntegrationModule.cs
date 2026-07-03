// PROJECT: SalesApp
// FILE: DbIntegrationModule.cs
// MỤC ĐÍCH: Xử lý các thao tác tích hợp, kết nối an toàn với Cơ Sở Dữ Liệu
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SalesApp
{
    public class DbIntegrationModule
    {
        // Chuỗi kết nối DB Bán hàng (Quản lý giỏ hàng/đơn hàng)
        private string _salesConnString = @"Server=localhost;Database=ModernSalesDB;Integrated Security=True;TrustServerCertificate=True;";

        // Chuỗi kết nối DB Kho hàng (Quản lý tồn kho)
        private string _warehouseConnString = @"Server=localhost;Database=WarehouseDB;Integrated Security=True;TrustServerCertificate=True;";

        // 1. Constructor mặc định (Dùng cho CartForm gọi đơn giản)
        public DbIntegrationModule()
        {
        }

        // 2. Constructor có tham số (Dùng cho các Form cũ lỡ truyền chuỗi kết nối vào)
        public DbIntegrationModule(string salesConnString)
        {
            this._salesConnString = salesConnString;
        }

        // =================================================================================
        // HÀM MỚI TỐI QUAN TRỌNG: XỬ LÝ LƯU NHIỀU ĐƠN HÀNG CÙNG LÚC SỬ DỤNG SQL TRANSACTION
        // =================================================================================
        public bool IntegrateMultipleOrders(List<CartItem> cartItems)
        {
            try
            {
                // Bước 1: KẾT NỐI KHO (WarehouseDB) ĐỂ KIỂM TRA & TRỪ TỒN KHO HÀNG LOẠT
                using (SqlConnection warehouseConn = new SqlConnection(_warehouseConnString))
                {
                    warehouseConn.Open();
                    SqlTransaction warehouseTx = warehouseConn.BeginTransaction(); // Bắt đầu Giao dịch an toàn

                    try
                    {
                        foreach (var item in cartItems)
                        {
                            // 1.1 Kiểm tra tồn kho của từng món
                            string checkSql = "SELECT StockQuantity FROM Inventory WHERE ProductName = @name";
                            int currentStock = 0;
                            using (SqlCommand checkCmd = new SqlCommand(checkSql, warehouseConn, warehouseTx))
                            {
                                checkCmd.Parameters.AddWithValue("@name", item.ProductName);
                                object result = checkCmd.ExecuteScalar();
                                if (result != null) currentStock = Convert.ToInt32(result);
                            }

                            // Nếu phát hiện 1 món thiếu hàng -> Hủy bỏ toàn bộ giao dịch
                            if (currentStock < item.Quantity)
                            {
                                warehouseTx.Rollback();
                                MessageBox.Show($"Sản phẩm '{item.ProductName}' chỉ còn {currentStock} chiếc. Không đủ để thanh toán!", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            // 1.2 Trừ kho cho món hàng đó
                            string updateSql = "UPDATE Inventory SET StockQuantity = StockQuantity - @qty WHERE ProductName = @name";
                            using (SqlCommand updateCmd = new SqlCommand(updateSql, warehouseConn, warehouseTx))
                            {
                                updateCmd.Parameters.AddWithValue("@name", item.ProductName);
                                updateCmd.Parameters.AddWithValue("@qty", item.Quantity);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        // Nếu quét qua hết giỏ hàng mà không lỗi gì -> Chốt giao dịch trừ kho
                        warehouseTx.Commit();
                    }
                    catch
                    {
                        warehouseTx.Rollback(); // Có lỗi bất ngờ thì hoàn tác toàn bộ
                        throw;
                    }
                }

                // Bước 2: KẾT NỐI BÁN HÀNG (ModernSalesDB) ĐỂ LƯU HÀNG LOẠT ĐƠN HÀNG
                using (SqlConnection salesConn = new SqlConnection(_salesConnString))
                {
                    salesConn.Open();
                    SqlTransaction salesTx = salesConn.BeginTransaction();
                    try
                    {
                        foreach (var item in cartItems)
                        {
                            string insertSql = "INSERT INTO Cart (ProductName, Quantity, TotalPrice) VALUES (@name, @qty, @total)";
                            using (SqlCommand insertCmd = new SqlCommand(insertSql, salesConn, salesTx))
                            {
                                insertCmd.Parameters.AddWithValue("@name", item.ProductName);
                                insertCmd.Parameters.AddWithValue("@qty", item.Quantity);
                                insertCmd.Parameters.AddWithValue("@total", item.TotalPrice);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        salesTx.Commit(); // Chốt lưu đơn hàng
                    }
                    catch
                    {
                        salesTx.Rollback();
                        throw;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =================================================================================
        // CÁC HÀM CŨ XỬ LÝ MUA LẺ (DUY TRÌ ĐỂ BACKWARD COMPATIBILITY CHO CHECKOUT FORM CŨ)
        // =================================================================================

        // Hàm kiểm tra tồn kho (Gọi TRƯỚC khi mở QR Code mua lẻ)
        public bool CheckInventory(string productName, int requestedQty)
        {
            try
            {
                using (SqlConnection warehouseConn = new SqlConnection(_warehouseConnString))
                {
                    warehouseConn.Open();
                    string checkSql = "SELECT StockQuantity FROM Inventory WHERE ProductName = @name";
                    int currentStock = 0;
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, warehouseConn))
                    {
                        checkCmd.Parameters.AddWithValue("@name", productName);
                        object result = checkCmd.ExecuteScalar();
                        if (result != null) currentStock = Convert.ToInt32(result);
                    }

                    if (currentStock < requestedQty)
                    {
                        MessageBox.Show($"Kho hàng không đủ! Sản phẩm này chỉ còn lại {currentStock} chiếc trong kho.",
                                        "Cảnh báo Tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra kho: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Phương thức thực hiện Tích hợp 2 Cơ sở dữ liệu (Gọi SAU khi thanh toán mua lẻ thành công)
        public bool IntegrateOrder(string productName, int qty, decimal total)
        {
            try
            {
                // Bước 1: KẾT NỐI CSDL KHO HÀNG (WarehouseDB) ĐỂ TRỪ TỒN KHO
                using (SqlConnection warehouseConn = new SqlConnection(_warehouseConnString))
                {
                    warehouseConn.Open();
                    // Do đã kiểm tra tồn kho ở hàm CheckInventory rồi, nên ở đây chỉ cần UPDATE trừ số lượng
                    string updateSql = "UPDATE Inventory SET StockQuantity = StockQuantity - @qty WHERE ProductName = @name";
                    using (SqlCommand updateCmd = new SqlCommand(updateSql, warehouseConn))
                    {
                        updateCmd.Parameters.AddWithValue("@name", productName);
                        updateCmd.Parameters.AddWithValue("@qty", qty);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                // Bước 2: KẾT NỐI CSDL BÁN HÀNG (ModernSalesDB) ĐỂ LƯU ĐƠN HÀNG
                using (SqlConnection salesConn = new SqlConnection(_salesConnString))
                {
                    salesConn.Open();
                    string insertSql = "INSERT INTO Cart (ProductName, Quantity, TotalPrice) VALUES (@name, @qty, @total)";

                    using (SqlCommand insertCmd = new SqlCommand(insertSql, salesConn))
                    {
                        insertCmd.Parameters.AddWithValue("@name", productName);
                        insertCmd.Parameters.AddWithValue("@qty", qty);
                        insertCmd.Parameters.AddWithValue("@total", total);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình tích hợp CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}