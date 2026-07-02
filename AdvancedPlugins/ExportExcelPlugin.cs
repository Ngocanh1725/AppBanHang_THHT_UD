// PROJECT: AdvancedPlugins
// FILE: ExportExcelPlugin.cs
using System;
using System.IO;
using System.Windows.Forms;
using PluginContract;

namespace AdvancedPlugins
{
    public class ExportExcelPlugin : IPlugin
    {
        public string Name => "Công cụ Xuất Báo Cáo (CSV/Excel)";
        public string Version => "1.0.0";
        public string Author => "Sinh Viên IT";

        public void Execute(Form hostForm)
        {
            // Mở hộp thoại chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (Mở bằng Excel)|*.csv";
            sfd.Title = "Lưu báo cáo doanh thu";
            sfd.FileName = "BaoCaoDoanhThu.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Trong thực tế, bạn sẽ SELECT từ SQL. 
                    // Ở đây ta ghi dữ liệu giả lập (Mock data) để demo chức năng.
                    string csvContent = "Mã Đơn,Tên Sản Phẩm,Số Lượng,Tổng Tiền\n";
                    csvContent += "DH001,Laptop Dell XPS,1,30000000\n";
                    csvContent += "DH002,Chuột Logitech,2,5000000\n";

                    // Lưu file
                    File.WriteAllText(sfd.FileName, csvContent, System.Text.Encoding.UTF8);

                    MessageBox.Show($"Xuất báo cáo thành công!\nFile được lưu tại:\n{sfd.FileName}",
                                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}