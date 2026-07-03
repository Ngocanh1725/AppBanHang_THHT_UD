// PROJECT: SalesApp
// FILE: CartForm.cs
using System;
using System.Linq;
using System.Windows.Forms;

namespace SalesApp
{
    public partial class CartForm : Form
    {
        private decimal grandTotal = 0;

        public CartForm()
        {
            InitializeComponent();
            LoadCart();
        }

        private void LoadCart()
        {
            // Hiển thị List từ Global lên DataGridView
            dgvCart.DataSource = null;
            dgvCart.DataSource = Global.ShoppingCart;

            // Tính tổng tiền
            grandTotal = Global.ShoppingCart.Sum(item => item.TotalPrice);
            lblTotalAmount.Text = $"Tổng thanh toán: {grandTotal:N0} VNĐ";

            btnCheckout.Enabled = Global.ShoppingCart.Count > 0;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Global.ShoppingCart.Clear();
            LoadCart();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            // 1. Mở Form quét QR code thanh toán (Truyền tổng tiền sang)
            PaymentForm paymentForm = new PaymentForm(grandTotal);

            if (paymentForm.ShowDialog() == DialogResult.OK)
            {
                // 2. Nếu quét mã OK -> Gọi Module Tích hợp CSDL để lưu TOÀN BỘ giỏ hàng
                DbIntegrationModule db = new DbIntegrationModule();

                if (db.IntegrateMultipleOrders(Global.ShoppingCart))
                {
                    MessageBox.Show("Thanh toán thành công! Hàng hóa đã được trừ kho.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Global.ShoppingCart.Clear(); // Xóa giỏ hàng sau khi mua xong
                    this.Close();
                }
            }
        }
    }
}