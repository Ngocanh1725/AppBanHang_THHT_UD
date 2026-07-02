// PROJECT: SalesApp
// FILE: ProductCard.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SalesApp
{
    public partial class ProductCard : UserControl
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        // Constructor nhận thêm Category để gán vào giao diện
        public ProductCard(string name, string category, decimal price, Color bgColor)
        {
            InitializeComponent();
            this.ProductName = name;
            this.ProductPrice = price;

            lblName.Text = name;
            lblCategory.Text = category; // Gán danh mục
            lblPrice.Text = $"{price:N0} đ";
            this.BackColor = bgColor;
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            // TÍCH HỢP GIAO DIỆN: Truyền dữ liệu qua Global để Form thanh toán lấy
            Global.ProductName = this.ProductName;
            Global.ProductPrice = this.ProductPrice;

            CheckoutForm checkout = new CheckoutForm();
            checkout.ShowDialog();
        }
    }
}