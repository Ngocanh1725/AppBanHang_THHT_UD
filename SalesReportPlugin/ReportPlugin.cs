// PROJECT: SalesReportPlugin
// FILE: ReportPlugin.cs
using System;
using System.Windows.Forms;
using PluginContract;

namespace SalesReportPlugin
{
    public class ReportPlugin : IPlugin
    {
        public string Name => "Báo Cáo Doanh Thu Plugin";

        // BỔ SUNG 2 THUỘC TÍNH NÀY THEO INTERFACE MỚI
        public string Version => "1.0.0";
        public string Author => "Sinh Viên IT";

        // CẬP NHẬT LẠI HÀM EXECUTE: Nhận thêm tham số Form hostForm
        public void Execute(Form hostForm)
        {
            // Mở form báo cáo khi Plugin được gọi
            ReportForm form = new ReportForm();
            form.ShowDialog();
        }
    }
}