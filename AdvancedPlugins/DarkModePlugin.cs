// PROJECT: AdvancedPlugins
// FILE: DarkModePlugin.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using PluginContract;

namespace AdvancedPlugins
{
    public class DarkModePlugin : IPlugin
    {
        public string Name => "Giao diện Tối / Sáng (Bật-Tắt)";
        public string Version => "2.0.0";
        public string Author => "Sinh Viên IT";

        // Biến static để lưu trạng thái đang bật hay tắt (Toggle)
        private static bool _isDarkMode = false;

        public void Execute(Form hostForm)
        {
            // Đảo trạng thái (Nếu đang tắt thì bật, đang bật thì tắt)
            _isDarkMode = !_isDarkMode;

            // Cài đặt màu sắc tương ứng
            Color bgColor = _isDarkMode ? Color.FromArgb(45, 52, 54) : Color.FromArgb(248, 249, 250);
            Color fgColor = _isDarkMode ? Color.White : Color.FromArgb(45, 52, 54);

            // Đổi màu nền của Form chính
            hostForm.BackColor = bgColor;

            // Tìm và đổi màu chữ Tiêu đề ("Sản phẩm")
            foreach (Control c in hostForm.Controls)
            {
                // Tìm Panel Header nằm ở trên cùng
                if (c is Panel && c.Dock == DockStyle.Top)
                {
                    foreach (Control lbl in c.Controls)
                    {
                        if (lbl is Label) lbl.ForeColor = fgColor; // Đổi màu chữ trắng/đen
                    }
                }
            }

            string statusMsg = _isDarkMode ? "Đã BẬT nền tối!" : "Đã TẮT nền tối (Trở về mặc định)!";
            MessageBox.Show(statusMsg, "Thông báo");
        }
    }
}