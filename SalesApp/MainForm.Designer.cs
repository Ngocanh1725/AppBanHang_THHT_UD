// PROJECT: SalesApp
// FILE: MainForm.Designer.cs
namespace SalesApp
{
    partial class MainForm
    {
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblPluginTitle;
        private System.Windows.Forms.FlowLayoutPanel flpPluginMenu;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnCart;

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnWarehouse = new Button();
            lblLogo = new Label();
            lblPluginTitle = new Label();
            flpPluginMenu = new FlowLayoutPanel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnCart = new Button();
            flpProducts = new FlowLayoutPanel();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(34, 47, 62);
            pnlSidebar.Controls.Add(btnWarehouse);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(lblPluginTitle);
            pnlSidebar.Controls.Add(flpPluginMenu);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.ForeColor = Color.White;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(20);
            pnlSidebar.Size = new Size(260, 659);
            pnlSidebar.TabIndex = 2;
            // 
            // btnWarehouse
            // 
            btnWarehouse.BackColor = Color.FromArgb(52, 73, 94);
            btnWarehouse.Cursor = Cursors.Hand;
            btnWarehouse.Dock = DockStyle.Top;
            btnWarehouse.FlatAppearance.BorderSize = 0;
            btnWarehouse.FlatStyle = FlatStyle.Flat;
            btnWarehouse.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnWarehouse.ForeColor = Color.White;
            btnWarehouse.Location = new Point(20, 100);
            btnWarehouse.Name = "btnWarehouse";
            btnWarehouse.Size = new Size(220, 50);
            btnWarehouse.TabIndex = 0;
            btnWarehouse.Text = "📦 Quản lý Kho hàng";
            btnWarehouse.UseVisualStyleBackColor = false;
            btnWarehouse.Click += BtnWarehouse_Click;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(220, 80);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "ShopApp.";
            // 
            // lblPluginTitle
            // 
            lblPluginTitle.Dock = DockStyle.Bottom;
            lblPluginTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPluginTitle.ForeColor = Color.FromArgb(200, 214, 229);
            lblPluginTitle.Location = new Point(20, 349);
            lblPluginTitle.Name = "lblPluginTitle";
            lblPluginTitle.Size = new Size(220, 40);
            lblPluginTitle.TabIndex = 2;
            lblPluginTitle.Text = "\nCÔNG CỤ TÍCH HỢP (PLUGIN)";
            // 
            // flpPluginMenu
            // 
            flpPluginMenu.Dock = DockStyle.Bottom;
            flpPluginMenu.FlowDirection = FlowDirection.TopDown;
            flpPluginMenu.Location = new Point(20, 389);
            flpPluginMenu.Name = "flpPluginMenu";
            flpPluginMenu.Size = new Size(220, 250);
            flpPluginMenu.TabIndex = 3;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnCart);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(260, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(30, 20, 30, 20);
            pnlHeader.Size = new Size(724, 90);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 52, 54);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 52);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sản phẩm";
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.FromArgb(253, 203, 110);
            btnCart.Cursor = Cursors.Hand;
            btnCart.Dock = DockStyle.Right;
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCart.Location = new Point(514, 20);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(180, 50);
            btnCart.TabIndex = 1;
            btnCart.Text = "\U0001f6d2 Xem Giỏ Hàng";
            btnCart.UseVisualStyleBackColor = false;
            btnCart.Click += BtnCart_Click;
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(260, 90);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(30, 10, 30, 30);
            flpProducts.Size = new Size(724, 569);
            flpProducts.TabIndex = 0;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(984, 659);
            Controls.Add(flpProducts);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Bán Hàng Hiện Đại";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }
    }
}