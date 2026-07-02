// PROJECT: SalesReportPlugin
// FILE: ReportForm.cs
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SalesReportPlugin
{
    public partial class ReportForm : Form
    {
        private string connectionString = @"Server=localhost;Database=SalesIntegrationDB;Integrated Security=True;TrustServerCertificate=True;";

        public ReportForm()
        {
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductName, Quantity, TotalPrice FROM Cart";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        decimal grandTotal = 0;
                        while (reader.Read())
                        {
                            string name = reader["ProductName"].ToString();
                            int qty = Convert.ToInt32(reader["Quantity"]);
                            decimal total = Convert.ToDecimal(reader["TotalPrice"]);

                            lstReport.Items.Add($"- {name} (SL: {qty}) => {total:N0} đ");
                            grandTotal += total;
                        }
                        lstReport.Items.Add("--------------------------------");
                        lstReport.Items.Add($"TỔNG DOANH THU: {grandTotal:N0} đ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Plugin: " + ex.Message);
            }
        }
    }
}