// PROJECT: SalesApp
// FILE: CheckoutForm.cs
using System;
using System.Windows.Forms;

namespace SalesApp
{
    public partial class CheckoutForm : Form
    {
        private string connectionString = @"Server=localhost;Database=SalesIntegrationDB;Integrated Security=True;TrustServerCertificate=True;";

        public CheckoutForm()
        {
            InitializeComponent();
            // Đọc dữ liệu từ biến toàn cục
            lblProductName.Text = $"{Global.ProductName}\nGiá: {Global.ProductPrice:N0} đ";
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int qty) && qty > 0)
            {
                // KHỞI TẠO MODULE CSDL
                DbIntegrationModule db = new DbIntegrationModule(connectionString);

                // KIỂM TRA KHO HÀNG TRƯỚC KHI HIỂN THỊ MÃ QR THANH TOÁN
                // Nếu kho không đủ hàng -> Dừng lại ngay lập tức (return)
                if (!db.CheckInventory(Global.ProductName, qty))
                {
                    return;
                }

                decimal total = qty * Global.ProductPrice;

                // Mở Form hiển thị mã QR và truyền tổng tiền vào
                PaymentForm paymentForm = new PaymentForm(total);

                // ShowDialog() sẽ chặn màn hình lại chờ người dùng thao tác.
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // Chỉ lưu vào CSDL sau khi thanh toán thành công
                    if (db.IntegrateOrder(Global.ProductName, qty, total))
                    {
                        MessageBox.Show("Thanh toán thành công! Đơn hàng đã được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Số lượng không hợp lệ!");
            }
        }
    }
}