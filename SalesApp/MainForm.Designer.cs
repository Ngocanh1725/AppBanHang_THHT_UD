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
        private System.Windows.Forms.FlowLayoutPanel flpPluginMenu; // Vùng chứa các nút Plugin động
        private System.Windows.Forms.Button btnWarehouse; // ĐƯA KHAI BÁO NÚT KHO HÀNG LÊN ĐÂY

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblPluginTitle = new System.Windows.Forms.Label();
            this.flpPluginMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            this.Text = "Hệ thống Bán Hàng Hiện Đại";
            this.Size = new System.Drawing.Size(1200, 750);
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250); // Nền xám cực nhạt
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // pnlSidebar (Menu bên trái)
            // 
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 260;
            // CHỈNH MÀU NỀN ĐẬM VÀ MÀU CHỮ SÁNG ĐỂ LUÔN NỔI BẬT
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(34, 47, 62);
            this.pnlSidebar.ForeColor = System.Drawing.Color.White;
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(20);

            // Logo chữ trên cùng Sidebar
            this.lblLogo.Text = "ShopApp.";
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Height = 80;

            // NÚT MỚI: QUẢN LÝ KHO HÀNG (Đã sửa thành biến toàn cục btnWarehouse)
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnWarehouse.Text = "📦 Quản lý Kho hàng";
            this.btnWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWarehouse.Height = 50;
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnWarehouse.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWarehouse.Click += new System.EventHandler(this.BtnWarehouse_Click);

            // THÊM VÀO SIDEBAR VÀ SẮP XẾP LẠI VỊ TRÍ
            this.pnlSidebar.Controls.Add(this.btnWarehouse);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.btnWarehouse.BringToFront(); // Nút Kho hàng ở dưới
            this.lblLogo.BringToFront();      // Ép Logo lên trên cùng nhất

            // Tiêu đề Plugin Menu
            this.lblPluginTitle.Text = "\nCÔNG CỤ TÍCH HỢP (PLUGIN)";
            this.lblPluginTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPluginTitle.ForeColor = System.Drawing.Color.FromArgb(200, 214, 229); // Xám sáng nổi bật
            this.lblPluginTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPluginTitle.Height = 40;
            this.pnlSidebar.Controls.Add(this.lblPluginTitle);

            // Khu vực chứa các nút Plugin tự động sinh ra (ở dưới cùng Sidebar)
            this.flpPluginMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpPluginMenu.Height = 250;
            this.flpPluginMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSidebar.Controls.Add(this.flpPluginMenu);

            // 
            // HEADER BÊN TRÊN
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;

            // Xóa chữ Khóa Học, chỉ để Sản Phẩm
            this.lblTitle.Text = "Sản phẩm";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.AutoSize = true;
            this.pnlHeader.Controls.Add(this.lblTitle);

            // 
            // KHU VỰC CHỨA CÁC THẺ SẢN PHẨM
            // 
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Padding = new System.Windows.Forms.Padding(30, 10, 30, 30);

            // Thêm các vùng vào giao diện
            this.Controls.Add(this.flpProducts);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.ResumeLayout(false);
        }
    }
}