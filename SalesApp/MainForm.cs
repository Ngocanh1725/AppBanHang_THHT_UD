// PROJECT: SalesApp
// FILE: MainForm.cs
using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using PluginContract;

namespace SalesApp
{
    public partial class MainForm : Form
    {
        // Chú ý: Đã trỏ về Database "ModernSalesDB"
        private string connectionString = @"Server=localhost;Database=ModernSalesDB;Integrated Security=True;TrustServerCertificate=True;";

        // Mảng màu pastel siêu nhạt giống thiết kế
        private Color[] pastelColors = {
            Color.FromArgb(240, 244, 255), // Xanh dương siêu nhạt
            Color.FromArgb(255, 243, 235), // Cam nhạt
            Color.FromArgb(245, 250, 245), // Xanh lá nhạt
            Color.FromArgb(252, 240, 245)  // Hồng nhạt
        };

        public MainForm()
        {
            InitializeComponent();

            // Tải sản phẩm
            LoadProductsAsCards();

            // Tải Menu Plugin
            BuildPluginMenu();
        }

        // =======================================================
        // HÀM BỊ THIẾU: TẢI DỮ LIỆU SẢN PHẨM TỪ CSDL VÀ VẼ THẺ (CARD)
        // =======================================================
        private void LoadProductsAsCards()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductName, Category, Price FROM Products";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int index = 0;
                        flpProducts.Controls.Clear();
                        while (reader.Read())
                        {
                            string name = reader["ProductName"].ToString();
                            string category = reader["Category"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            Color bgColor = pastelColors[index % pastelColors.Length];
                            ProductCard card = new ProductCard(name, category, price, bgColor);
                            flpProducts.Controls.Add(card);
                            index++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối DB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================
        // SỰ KIỆN: MỞ FORM QUẢN LÝ KHO HÀNG
        // =======================================================
        private void BtnWarehouse_Click(object sender, EventArgs e)
        {
            WarehouseForm whForm = new WarehouseForm();
            whForm.ShowDialog();

            // Load lại sản phẩm nhỡ có thay đổi (thêm/sửa/xóa) trong kho
            LoadProductsAsCards();
        }

        // =======================================================
        // TÍCH HỢP PLUGIN: TỰ ĐỘNG SINH MENU TỪ FILE DLL
        // =======================================================
        private void BuildPluginMenu()
        {
            string pluginPath = Path.Combine(Application.StartupPath, "Plugins");
            if (!Directory.Exists(pluginPath)) Directory.CreateDirectory(pluginPath);

            string[] dllFiles = Directory.GetFiles(pluginPath, "*.dll");
            flpPluginMenu.Controls.Clear(); // Xóa menu cũ (nếu có)

            foreach (string file in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);

                            // TẠO NÚT BẤM (BUTTON)
                            Button btnPlugin = new Button();
                            btnPlugin.Text = "🧩 " + plugin.Name;
                            btnPlugin.Width = 220;
                            btnPlugin.Height = 45;
                            btnPlugin.FlatStyle = FlatStyle.Flat;
                            btnPlugin.FlatAppearance.BorderSize = 0;

                            // CHỈNH MÀU NÚT NỔI BẬT TRÊN NỀN TỐI
                            btnPlugin.BackColor = Color.FromArgb(87, 101, 116);
                            btnPlugin.ForeColor = Color.White;

                            btnPlugin.TextAlign = ContentAlignment.MiddleLeft;
                            btnPlugin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                            btnPlugin.Cursor = Cursors.Hand;
                            btnPlugin.Margin = new Padding(0, 0, 0, 10);

                            // Hiệu ứng di chuột
                            btnPlugin.MouseEnter += (s, e) => { btnPlugin.BackColor = Color.FromArgb(116, 125, 140); };
                            btnPlugin.MouseLeave += (s, e) => { btnPlugin.BackColor = Color.FromArgb(87, 101, 116); };

                            // Sự kiện Click chạy Plugin
                            btnPlugin.Click += (s, e) => {
                                plugin.Execute(this);
                            };

                            flpPluginMenu.Controls.Add(btnPlugin);
                        }
                    }
                }
                catch { /* Bỏ qua file lỗi */ }
            }

            if (flpPluginMenu.Controls.Count == 0)
            {
                Label lblNoPlugin = new Label
                {
                    Text = "Chưa có Plugin.",
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    AutoSize = true
                };
                flpPluginMenu.Controls.Add(lblNoPlugin);
            }
        }
    }
}