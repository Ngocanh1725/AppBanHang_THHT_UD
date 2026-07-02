// PROJECT: SalesApp
// FILE: WarehouseForm.cs
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SalesApp
{
    public partial class WarehouseForm : Form
    {
        private string connString = @"Server=localhost;Database=WarehouseDB;Integrated Security=True;TrustServerCertificate=True;";

        public WarehouseForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string search = "")
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT Id, ProductName AS [Tên Sản Phẩm], StockQuantity AS [Tồn Kho] FROM Inventory WHERE ProductName LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInventory.DataSource = dt;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e) => LoadData(txtSearch.Text);

        private void DgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtName.Text = row.Cells["Tên Sản Phẩm"].Value.ToString();
                txtQty.Text = row.Cells["Tồn Kho"].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtQty.Text)) return;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Inventory (ProductName, StockQuantity) VALUES (@name, @qty)", conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                cmd.ExecuteNonQuery();
            }
            LoadData();
            MessageBox.Show("Thêm thành công!");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Inventory SET ProductName=@name, StockQuantity=@qty WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                cmd.ExecuteNonQuery();
            }
            LoadData();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Inventory WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
            }
            LoadData();
            txtId.Clear(); txtName.Clear(); txtQty.Clear();
            MessageBox.Show("Đã xóa!");
        }
    }
}