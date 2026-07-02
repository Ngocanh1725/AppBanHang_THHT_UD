// PROJECT: SalesApp
// FILE: ProductCard.Designer.cs
namespace SalesApp
{
    partial class ProductCard
    {
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnBuy;

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Cấu hình thẻ bám sát thiết kế (Màu nền pastel, không viền, bo tròn ẩn)
            this.Size = new System.Drawing.Size(200, 240);
            this.Margin = new System.Windows.Forms.Padding(15);
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Cursor = System.Windows.Forms.Cursors.Hand;

            // Nhãn Phân loại (Category - Nằm trên cùng)
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCategory.Height = 25;
            this.lblCategory.Text = "Danh mục";

            // Nhãn Tên sản phẩm
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Height = 60;
            this.lblName.Text = "Tên SP";

            // Nhãn Giá
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(232, 65, 24); // Màu cam đỏ nổi bật
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrice.Height = 30;
            this.lblPrice.Text = "Giá";

            // Nút Thêm vào giỏ
            this.btnBuy.BackColor = System.Drawing.Color.White;
            this.btnBuy.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.FlatAppearance.BorderSize = 0; // Bỏ viền để phẳng hơn
            this.btnBuy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuy.Height = 45;
            this.btnBuy.Text = "Thêm vào giỏ";
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);

            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnBuy);
            this.ResumeLayout(false);
        }
    }
}