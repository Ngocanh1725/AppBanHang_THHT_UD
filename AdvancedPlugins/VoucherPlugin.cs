// PROJECT: AdvancedPlugins
// FILE: VoucherPlugin.cs
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using PluginContract;

namespace AdvancedPlugins
{
    public class VoucherPlugin : IPlugin
    {
        public string Name => "Công cụ Khuyến Mãi (Tùy chọn)";
        public string Version => "2.5.0";
        public string Author => "Sinh Viên IT";

        public void Execute(Form hostForm)
        {
            FlowLayoutPanel flpProducts = null;
            foreach (Control c in hostForm.Controls)
            {
                if (c is FlowLayoutPanel) { flpProducts = (FlowLayoutPanel)c; break; }
            }

            if (flpProducts == null || flpProducts.Controls.Count == 0) return;

            // =======================================================
            // TẠO GIAO DIỆN FORM CẤU HÌNH BẰNG CODE (THAY THẾ MESSAGEBOX)
            // =======================================================
            Form setupForm = new Form
            {
                Text = "Cấu hình Khuyến Mãi",
                Size = new Size(420, 500),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            // Thanh Header màu vàng cam
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(253, 203, 110) };
            Label lblHeader = new Label { Text = "🎁 THIẾT LẬP VOUCHER", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
            pnlHeader.Controls.Add(lblHeader);

            Label lblPercent = new Label { Text = "Mức giảm giá (%):", AutoSize = true, Location = new Point(20, 85), Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            NumericUpDown numPercent = new NumericUpDown { Location = new Point(160, 83), Size = new Size(80, 25), Minimum = 1, Maximum = 99, Value = 20 };

            Label lblSelect = new Label { Text = "Chọn sản phẩm áp dụng:", AutoSize = true, Location = new Point(20, 130), Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

            // Danh sách Checkbox đẹp không viền
            CheckedListBox chkProducts = new CheckedListBox
            {
                Location = new Point(20, 160),
                Size = new Size(360, 220),
                CheckOnClick = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(245, 246, 250),
                Font = new Font("Segoe UI", 10F)
            };

            foreach (Control card in flpProducts.Controls)
            {
                PropertyInfo nameProp = card.GetType().GetProperty("ProductName");
                if (nameProp != null) chkProducts.Items.Add(nameProp.GetValue(card).ToString(), true);
            }

            // Nút Áp dụng to, phẳng, màu đỏ cam
            Button btnApply = new Button
            {
                Text = "ÁP DỤNG NGAY",
                Location = new Point(20, 400),
                Size = new Size(360, 45),
                BackColor = Color.FromArgb(232, 65, 24),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnApply.FlatAppearance.BorderSize = 0;

            // Xử lý sự kiện khi bấm áp dụng
            btnApply.Click += (s, e) =>
            {
                if (chkProducts.CheckedItems.Count == 0) return;
                decimal discountPercent = numPercent.Value;
                foreach (Control card in flpProducts.Controls)
                {
                    PropertyInfo nameProp = card.GetType().GetProperty("ProductName");
                    PropertyInfo priceProp = card.GetType().GetProperty("ProductPrice");

                    if (nameProp != null && priceProp != null)
                    {
                        string pName = nameProp.GetValue(card).ToString();
                        if (chkProducts.CheckedItems.Contains(pName))
                        {
                            decimal newPrice = (decimal)priceProp.GetValue(card) * (1m - (discountPercent / 100m));
                            priceProp.SetValue(card, newPrice);
                            foreach (Control child in card.Controls)
                            {
                                if (child is Label lbl && lbl.Text.Contains("đ"))
                                {
                                    lbl.Text = $"{newPrice:N0} đ (-{discountPercent}%)";
                                    lbl.ForeColor = Color.Red; break;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Áp dụng khuyến mãi thành công!", "Hoàn tất");
                setupForm.Close();
            };

            setupForm.Controls.Add(pnlHeader); setupForm.Controls.Add(lblPercent); setupForm.Controls.Add(numPercent);
            setupForm.Controls.Add(lblSelect); setupForm.Controls.Add(chkProducts); setupForm.Controls.Add(btnApply);

            // Hiển thị form tự thiết kế
            setupForm.ShowDialog();
        }
    }
}