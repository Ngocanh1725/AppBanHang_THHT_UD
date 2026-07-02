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
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();

            this.Text = "Quản lý Kho Hàng (WarehouseDB)";
            this.Size = new System.Drawing.Size(800, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Tiêu đề
            this.lblTitle.Text = "📦 QUẢN LÝ TỒN KHO";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;

            // Tìm kiếm
            this.txtSearch.Location = new System.Drawing.Point(20, 60);
            this.txtSearch.Size = new System.Drawing.Size(300, 30);
            this.txtSearch.PlaceholderText = "Nhập tên sản phẩm để tìm...";

            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Location = new System.Drawing.Point(330, 59);
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // DataGridView
            this.dgvInventory.Location = new System.Drawing.Point(20, 100);
            this.dgvInventory.Size = new System.Drawing.Size(500, 380);
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInventory_CellClick);

            // Khung nhập liệu (Bên phải)
            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label { Text = "ID:", Location = new System.Drawing.Point(540, 100), AutoSize = true };
            this.txtId.Location = new System.Drawing.Point(540, 125);
            this.txtId.Size = new System.Drawing.Size(220, 30);
            this.txtId.ReadOnly = true;

            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label { Text = "Tên SP:", Location = new System.Drawing.Point(540, 170), AutoSize = true };
            this.txtName.Location = new System.Drawing.Point(540, 195);
            this.txtName.Size = new System.Drawing.Size(220, 30);

            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label { Text = "Số lượng tồn:", Location = new System.Drawing.Point(540, 240), AutoSize = true };
            this.txtQty.Location = new System.Drawing.Point(540, 265);
            this.txtQty.Size = new System.Drawing.Size(220, 30);

            // Các nút CRUD
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.Location = new System.Drawing.Point(540, 320);
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new System.Drawing.Point(660, 320);
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(253, 203, 110);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(540, 370);
            this.btnDelete.Size = new System.Drawing.Size(220, 40);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(214, 48, 49);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtSearch); this.Controls.Add(btnSearch);
            this.Controls.Add(dgvInventory);
            this.Controls.Add(l1); this.Controls.Add(txtId);
            this.Controls.Add(l2); this.Controls.Add(txtName);
            this.Controls.Add(l3); this.Controls.Add(txtQty);
            this.Controls.Add(btnAdd); this.Controls.Add(btnUpdate); this.Controls.Add(btnDelete);

            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}