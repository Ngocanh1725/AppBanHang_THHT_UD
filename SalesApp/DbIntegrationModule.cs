// PROJECT: SalesApp
// FILE: DbIntegrationModule.cs
// MỤC ĐÍCH: Tích hợp CSDL (Đồng bộ giữa DB Bán Hàng và DB Kho Hàng)
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SalesApp
{
    public class DbIntegrationModule
    {
        // Chuỗi kết nối DB Bán hàng (Nhận từ MainForm/CheckoutForm truyền vào)
        private string _salesConnString;

        // Chuỗi kết nối DB Kho hàng (Định nghĩa trực tiếp để tích hợp)
        // Chú ý: Đổi 'localhost' thành tên server của bạn nếu cần
        private string _warehouseConnString = @"Server=localhost;Database=WarehouseDB;Integrated Security=True;TrustServerCertificate=True;";

        public DbIntegrationModule(string connString)
        {
            this._salesConnString = connString;
        }

        // BƯỚC MỚI: HÀM KIỂM TRA TỒN KHO (Được gọi TRƯỚC khi mở QR Code)
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

        // Phương thức thực hiện Tích hợp 2 Cơ sở dữ liệu (Gọi SAU khi thanh toán)
        public bool IntegrateOrder(string productName, int qty, decimal total)
        {
            try
            {
                // =================================================================
                // BƯỚC 1: KẾT NỐI CSDL KHO HÀNG (WarehouseDB) ĐỂ TRỪ TỒN KHO
                // =================================================================
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

                // =================================================================
                // BƯỚC 2: KẾT NỐI CSDL BÁN HÀNG (ModernSalesDB) ĐỂ LƯU ĐƠN HÀNG
                // =================================================================
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

                return true; // Hoàn tất tích hợp cả 2 DB thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình tích hợp CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}