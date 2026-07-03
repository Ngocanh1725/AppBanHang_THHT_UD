// PROJECT: SalesApp
// FILE: CartForm.Designer.cs
namespace SalesApp
{
    partial class CartForm
    {
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlBottom;

        private void InitializeComponent()
        {
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.Text = "Giỏ Hàng Của Bạn";
            this.Size = new System.Drawing.Size(650, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Lưới hiển thị giỏ hàng
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Panel chứa nút thanh toán bên dưới
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 80;
            this.pnlBottom.BackColor = System.Drawing.Color.White;

            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(232, 65, 24);
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 25);
            this.lblTotalAmount.Text = "Tổng tiền: 0 đ";

            this.btnClear.Text = "Xóa giỏ hàng";
            this.btnClear.Location = new System.Drawing.Point(330, 20);
            this.btnClear.Size = new System.Drawing.Size(120, 45);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            this.btnCheckout.Text = "THANH TOÁN";
            this.btnCheckout.Location = new System.Drawing.Point(460, 20);
            this.btnCheckout.Size = new System.Drawing.Size(150, 45);
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);

            this.pnlBottom.Controls.Add(lblTotalAmount);
            this.pnlBottom.Controls.Add(btnClear);
            this.pnlBottom.Controls.Add(btnCheckout);

            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlBottom);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}