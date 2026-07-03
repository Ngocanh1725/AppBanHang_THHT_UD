// PROJECT: AdvancedPlugins
// FILE: ExportExcelPlugin.cs
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient; // Thư viện kết nối CSDL
using PluginContract;

namespace AdvancedPlugins
{
    public class ExportExcelPlugin : IPlugin
    {
        public string Name => "Báo Cáo Thống Kê & Xuất CSV";
        public string Version => "4.0.0";
        public string Author => "Sinh Viên IT";

        // Chuỗi kết nối DB (Sửa lại nếu máy bạn dùng thông số khác)
        private string connectionString = @"Server=localhost;Database=ModernSalesDB;Integrated Security=True;TrustServerCertificate=True;";

        public void Execute(Form hostForm)
        {
            // 1. TẠO GIAO DIỆN BÁO CÁO (DASHBOARD)
            Form reportForm = new Form
            {
                Text = "Dashboard Báo Cáo Doanh Thu (Real-time)",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F)
            };

            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(9, 132, 227) };
            Label lblHeader = new Label { Text = "📈 THỐNG KÊ DOANH THU THỰC TẾ", Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
            pnlHeader.Controls.Add(lblHeader);

            // 2. BIỂU ĐỒ TRÒN (PIE CHART)
            Chart pieChart = new Chart { Location = new Point(20, 80), Size = new Size(350, 350) };
            ChartArea chartArea = new ChartArea();
            pieChart.ChartAreas.Add(chartArea);
            Series series = new Series { Name = "Sales", ChartType = SeriesChartType.Pie, IsValueShownAsLabel = true };
            pieChart.Series.Add(series);
            pieChart.Titles.Add(new Title("Doanh thu theo danh mục", Docking.Top, new Font("Segoe UI", 12F, FontStyle.Bold), Color.Black));

            // 3. BẢNG DỮ LIỆU CHI TIẾT (DATAGRIDVIEW)
            DataGridView dgv = new DataGridView
            {
                Location = new Point(390, 80),
                Size = new Size(370, 350),
                BackgroundColor = Color.White,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None
            };
            dgv.Columns.Add("Cat", "Danh mục");
            dgv.Columns.Add("Rev", "Doanh thu (VNĐ)");

            // ====================================================================
            // TÍCH HỢP CSDL NÂNG CAO: DÙNG LỆNH JOIN, GROUP BY VÀ SUM
            // ====================================================================
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lấy Tên danh mục (từ bảng Products) và Tổng tiền (từ bảng Cart), nhóm theo Danh mục
                    string query = @"
                        SELECT p.Category, SUM(c.TotalPrice) AS TotalRevenue
                        FROM Cart c
                        INNER JOIN Products p ON c.ProductName = p.ProductName
                        GROUP BY p.Category";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool hasData = false;
                        while (reader.Read())
                        {
                            hasData = true;
                            string category = reader["Category"].ToString();
                            decimal revenue = Convert.ToDecimal(reader["TotalRevenue"]);

                            // Bơm dữ liệu thật vào Biểu đồ
                            series.Points.AddXY(category, revenue);

                            // Bơm dữ liệu thật vào Bảng
                            dgv.Rows.Add(category, revenue.ToString("N0"));
                        }

                        if (!hasData)
                        {
                            MessageBox.Show("Chưa có đơn hàng nào được bán ra!", "Thông báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 4. NÚT XUẤT FILE CSV (XUẤT ĐỘNG TỪ DATAGRIDVIEW)
            Button btnExport = new Button
            {
                Text = "💾 XUẤT RA FILE EXCEL (.CSV)",
                Location = new Point(250, 480),
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(0, 184, 148),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnExport.FlatAppearance.BorderSize = 0;

            btnExport.Click += (s, e) =>
            {
                if (dgv.Rows.Count == 0) return;

                SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV File|*.csv", FileName = "BaoCao_ThucTe.csv" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvData = new StringBuilder();
                    csvData.AppendLine("Danh muc,Doanh thu (VND)");

                    // Quét từng dòng trong bảng để tạo file (Dữ liệu xuất ra thay đổi theo biểu đồ)
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        string cat = row.Cells[0].Value.ToString();
                        // Xóa dấu phẩy của tiền tệ để không bị lỗi cột trong file CSV
                        string rev = row.Cells[1].Value.ToString().Replace(",", "").Replace(".", "");
                        csvData.AppendLine($"{cat},{rev}");
                    }

                    File.WriteAllText(sfd.FileName, csvData.ToString(), System.Text.Encoding.UTF8);
                    MessageBox.Show("Đã xuất báo cáo ra file thành công!", "Hoàn tất");
                }
            };

            reportForm.Controls.Add(pnlHeader);
            reportForm.Controls.Add(pieChart);
            reportForm.Controls.Add(dgv);
            reportForm.Controls.Add(btnExport);

            reportForm.ShowDialog();
        }
    }
}