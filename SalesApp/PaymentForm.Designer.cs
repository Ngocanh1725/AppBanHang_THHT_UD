// PROJECT: SalesApp
// FILE: PaymentForm.Designer.cs
namespace SalesApp
{
    partial class PaymentForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblInstruction;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();

            // Cấu hình Form
            this.Text = "Thanh toán VNPay / Momo";
            this.Size = new System.Drawing.Size(350, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Tiêu đề
            this.lblTitle.Text = "QUÉT MÃ ĐỂ THANH TOÁN";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 50;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Số tiền cần thanh toán
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(232, 65, 24);
            this.lblAmount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAmount.Height = 40;
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Ảnh QR Code (Dùng API tạo QR code tự động)
            this.picQRCode.Size = new System.Drawing.Size(200, 200);
            this.picQRCode.Location = new System.Drawing.Point(65, 100);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // Gọi API lấy ảnh QR Code giả lập
            this.picQRCode.ImageLocation = "https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=MockupPaymentVNPay";

            // Hướng dẫn
            this.lblInstruction.Text = "Sử dụng App Ngân hàng hoặc Momo\nđể quét mã QR phía trên.";
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInstruction.ForeColor = System.Drawing.Color.Gray;
            this.lblInstruction.Location = new System.Drawing.Point(0, 310);
            this.lblInstruction.Size = new System.Drawing.Size(330, 40);
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Nút Xác nhận
            this.btnConfirm.Text = "TÔI ĐÃ QUÉT MÃ";
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(0, 184, 148); // Màu xanh lá
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(30, 365);
            this.btnConfirm.Size = new System.Drawing.Size(270, 45);
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);

            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTitle);

            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
        }
    }
}