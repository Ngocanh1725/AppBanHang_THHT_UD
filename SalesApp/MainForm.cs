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
        private string connectionString = @"Server=localhost;Database=ModernSalesDB;Integrated Security=True;TrustServerCertificate=True;";

        private Color[] pastelColors = {
            Color.FromArgb(240, 244, 255),
            Color.FromArgb(255, 243, 235),
            Color.FromArgb(245, 250, 245),
            Color.FromArgb(252, 240, 245)
        };

        public MainForm()
        {
            InitializeComponent();
            LoadProductsAsCards();
            BuildPluginMenu();
        }

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

        private void BtnWarehouse_Click(object sender, EventArgs e)
        {
            WarehouseForm whForm = new WarehouseForm();
            whForm.ShowDialog();
            LoadProductsAsCards();
        }

        // =======================================================
        // HÀM MỚI THÊM: SỰ KIỆN KHI BẤM NÚT GIỎ HÀNG
        // =======================================================
        private void BtnCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.ShowDialog();
        }

        private void BuildPluginMenu()
        {
            string pluginPath = Path.Combine(Application.StartupPath, "Plugins");
            if (!Directory.Exists(pluginPath)) Directory.CreateDirectory(pluginPath);

            string[] dllFiles = Directory.GetFiles(pluginPath, "*.dll");
            flpPluginMenu.Controls.Clear();

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

                            Button btnPlugin = new Button();
                            btnPlugin.Text = "🧩 " + plugin.Name;
                            btnPlugin.Width = 220;
                            btnPlugin.Height = 45;
                            btnPlugin.FlatStyle = FlatStyle.Flat;
                            btnPlugin.FlatAppearance.BorderSize = 0;
                            btnPlugin.BackColor = Color.FromArgb(87, 101, 116);
                            btnPlugin.ForeColor = Color.White;
                            btnPlugin.TextAlign = ContentAlignment.MiddleLeft;
                            btnPlugin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                            btnPlugin.Cursor = Cursors.Hand;
                            btnPlugin.Margin = new Padding(0, 0, 0, 10);

                            btnPlugin.MouseEnter += (s, e) => { btnPlugin.BackColor = Color.FromArgb(116, 125, 140); };
                            btnPlugin.MouseLeave += (s, e) => { btnPlugin.BackColor = Color.FromArgb(87, 101, 116); };

                            btnPlugin.Click += (s, e) => {
                                plugin.Execute(this);
                            };

                            flpPluginMenu.Controls.Add(btnPlugin);
                        }
                    }
                }
                catch { }
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