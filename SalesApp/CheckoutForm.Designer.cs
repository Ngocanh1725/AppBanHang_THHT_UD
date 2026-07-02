// PROJECT: SalesApp
// FILE: CheckoutForm.Designer.cs
namespace SalesApp
{
    partial class CheckoutForm
    {
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnConfirm;

        private void InitializeComponent()
        {
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName.Location = new System.Drawing.Point(20, 20);

            this.lblQuantity.Text = "Nhập số lượng:";
            this.lblQuantity.Location = new System.Drawing.Point(20, 70);

            this.txtQuantity.Location = new System.Drawing.Point(120, 67);
            this.txtQuantity.Width = 100;

            this.btnConfirm.Text = "Xác nhận Mua";
            this.btnConfirm.Location = new System.Drawing.Point(20, 110);
            this.btnConfirm.Width = 200;
            this.btnConfirm.Height = 40;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);

            this.Text = "Thanh toán (Tích hợp UI & DB)";
            this.Size = new System.Drawing.Size(350, 220);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnConfirm);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}