// PROJECT: SalesApp
// FILE: ProductCard.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SalesApp
{
    public partial class ProductCard : UserControl
    {
        // Các thuộc tính lưu trữ thông tin sản phẩm
        public string ProductName { get; private set; }
        public string ProductCategory { get; private set; }
        public decimal ProductPrice { get; set; } // Cho phép get/set để Plugin Khuyến mãi có thể sửa giá

        // Constructor nhận dữ liệu từ MainForm truyền vào
        public ProductCard(string name, string category, decimal price, Color bgColor)
        {
            InitializeComponent();

            // Gán dữ liệu vào biến
            this.ProductName = name;
            this.ProductCategory = category;
            this.ProductPrice = price;

            // Cài đặt giao diện
            this.BackColor = bgColor;
            lblName.Text = name;
            lblCategory.Text = category;
            lblPrice.Text = $"{price:N0} đ";
        }

        // Sự kiện khi người dùng bấm nút "Thêm vào giỏ"
        private void BtnBuy_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem sản phẩm đã có trong giỏ (Global.ShoppingCart) chưa
            var existingItem = Global.ShoppingCart.Find(x => x.ProductName == this.ProductName);

            if (existingItem != null)
            {
                // Nếu có rồi thì tăng số lượng lên 1
                existingItem.Quantity++;
            }
            else
            {
                // Nếu chưa có thì thêm mới vào giỏ
                Global.ShoppingCart.Add(new CartItem
                {
                    ProductName = this.ProductName,
                    Price = this.ProductPrice,
                    Quantity = 1
                });
            }

            // Hiển thị thông báo thân thiện
            MessageBox.Show($"Đã thêm '{this.ProductName}' vào giỏ hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}