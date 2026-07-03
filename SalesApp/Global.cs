// PROJECT: SalesApp
// FILE: Global.cs
using System.Collections.Generic;

namespace SalesApp
{
    // Cấu trúc 1 món hàng trong giỏ
    public class CartItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }

    public static class Global
    {
        // Danh sách chứa các mặt hàng khách đã chọn (Giỏ hàng toàn cục)
        public static List<CartItem> ShoppingCart = new List<CartItem>();
    }
}