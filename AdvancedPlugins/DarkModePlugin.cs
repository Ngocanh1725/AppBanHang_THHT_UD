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
        public string Version => "2.1.0";
        public string Author => "Sinh Viên IT";

        private static bool _isDarkMode = false;

        public void Execute(Form hostForm)
        {
            _isDarkMode = !_isDarkMode;

            Color bgColor = _isDarkMode ? Color.FromArgb(34, 47, 62) : Color.FromArgb(248, 249, 250);
            Color fgColor = _isDarkMode ? Color.White : Color.FromArgb(45, 52, 54);

            hostForm.BackColor = bgColor;

            foreach (Control c in hostForm.Controls)
            {
                if (c is Panel && c.Dock == DockStyle.Top)
                {
                    foreach (Control lbl in c.Controls)
                    {
                        if (lbl is Label) lbl.ForeColor = fgColor;
                    }
                }
            }

            // GỌI HÀM HIỂN THỊ GIAO DIỆN THÔNG BÁO HIỆN ĐẠI TỰ CODE BÊN DƯỚI
            ShowModernAlert(_isDarkMode ? "Đã BẬT nền tối thành công!" : "Đã KHÔI PHỤC nền sáng!");
        }

        // HÀM TẠO FORM THÔNG BÁO THAY THẾ MESSAGEBOX
        private void ShowModernAlert(string message)
        {
            Form alert = new Form();
            alert.FormBorderStyle = FormBorderStyle.None; // Bỏ viền Windows cũ
            alert.Size = new Size(350, 100);
            alert.BackColor = Color.FromArgb(46, 204, 113); // Xanh lá cây thành công
            alert.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label();
            lbl.Text = "✔ " + message;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            Button btnOk = new Button();
            btnOk.Text = "ĐÓNG";
            btnOk.Dock = DockStyle.Bottom;
            btnOk.Height = 35;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.BackColor = Color.FromArgb(39, 174, 96); // Xanh lá đậm hơn khi làm nút
            btnOk.ForeColor = Color.White;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.Cursor = Cursors.Hand;
            btnOk.Click += (s, e) => alert.Close();

            alert.Controls.Add(lbl);
            alert.Controls.Add(btnOk);
            alert.ShowDialog();
        }
    }
}