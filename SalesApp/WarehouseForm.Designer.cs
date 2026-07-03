// PROJECT: SalesApp
// FILE: WarehouseForm.Designer.cs
namespace SalesApp
{
    partial class WarehouseForm
    {
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHeader;

        private void InitializeComponent()
        {
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            this.Text = "Quản lý Kho Hàng Hiện Đại";
            this.Size = new System.Drawing.Size(850, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White; // Nền trắng hiện đại
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Header
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(34, 47, 62);

            this.lblTitle.Text = "📦 QUẢN LÝ TỒN KHO";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;
            this.pnlHeader.Controls.Add(lblTitle);

            // Tìm kiếm
            this.txtSearch.Location = new System.Drawing.Point(20, 90);
            this.txtSearch.Size = new System.Drawing.Size(350, 30);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);

            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.Location = new System.Drawing.Point(380, 89);
            this.btnSearch.Size = new System.Drawing.Size(120, 32);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // DataGridView hiện đại
            this.dgvInventory.Location = new System.Drawing.Point(20, 140);
            this.dgvInventory.Size = new System.Drawing.Size(480, 400);
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.EnableHeadersVisualStyles = false;
            this.dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(223, 230, 233);
            this.dgvInventory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvInventory.ColumnHeadersHeight = 40;
            this.dgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInventory_CellClick);

            // Khung nhập liệu (Bên phải)
            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label { Text = "Mã (ID):", Location = new System.Drawing.Point(530, 140), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            this.txtId.Location = new System.Drawing.Point(530, 165); this.txtId.Size = new System.Drawing.Size(280, 30); this.txtId.ReadOnly = true;

            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label { Text = "Tên Sản Phẩm:", Location = new System.Drawing.Point(530, 210), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            this.txtName.Location = new System.Drawing.Point(530, 235); this.txtName.Size = new System.Drawing.Size(280, 30);

            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label { Text = "Số lượng tồn kho:", Location = new System.Drawing.Point(530, 280), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            this.txtQty.Location = new System.Drawing.Point(530, 305); this.txtQty.Size = new System.Drawing.Size(280, 30);

            // Nút Thêm, Sửa, Xóa (Bỏ viền)
            this.btnAdd.Text = "+ Thêm mới";
            this.btnAdd.Location = new System.Drawing.Point(530, 360); this.btnAdd.Size = new System.Drawing.Size(130, 45);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 184, 148); this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand; this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new System.Drawing.Point(680, 360); this.btnUpdate.Size = new System.Drawing.Size(130, 45);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(253, 203, 110); this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand; this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnDelete.Text = "Xóa sản phẩm";
            this.btnDelete.Location = new System.Drawing.Point(530, 420); this.btnDelete.Size = new System.Drawing.Size(280, 45);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(214, 48, 49); this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand; this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.Controls.Add(pnlHeader);
            this.Controls.Add(txtSearch); this.Controls.Add(btnSearch);
            this.Controls.Add(dgvInventory);
            this.Controls.Add(l1); this.Controls.Add(txtId);
            this.Controls.Add(l2); this.Controls.Add(txtName);
            this.Controls.Add(l3); this.Controls.Add(txtQty);
            this.Controls.Add(btnAdd); this.Controls.Add(btnUpdate); this.Controls.Add(btnDelete);

            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}