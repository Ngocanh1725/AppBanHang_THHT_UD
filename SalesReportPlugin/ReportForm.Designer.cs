// PROJECT: SalesReportPlugin
// FILE: ReportForm.Designer.cs
namespace SalesReportPlugin
{
    partial class ReportForm
    {
        private System.Windows.Forms.ListBox lstReport;
        private System.Windows.Forms.Label lblTitle;

        private void InitializeComponent()
        {
            this.lstReport = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblTitle.Text = "BÁO CÁO DOANH THU TỪ GIỎ HÀNG";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 30;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lstReport.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Text = "Plugin Báo Cáo";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lstReport);
            this.Controls.Add(this.lblTitle);
            this.ResumeLayout(false);
        }
    }
}