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
        public string Version => "2.0.0";
        public string Author => "Sinh Viên IT";

        public void Execute(Form hostForm)
        {
            // 1. TÌM KIẾM LƯỚI CHỨA SẢN PHẨM TRÊN FORM GỐC
            FlowLayoutPanel flpProducts = null;
            foreach (Control c in hostForm.Controls)
            {
                if (c is FlowLayoutPanel)
                {
                    flpProducts = (FlowLayoutPanel)c;
                    break;
                }
            }

            if (flpProducts == null || flpProducts.Controls.Count == 0)
            {
                MessageBox.Show("Không tìm thấy danh sách sản phẩm trên màn hình chính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. TẠO GIAO DIỆN FORM CẤU HÌNH KHUYẾN MÃI (Bằng Code)
            Form setupForm = new Form
            {
                Text = "Cấu hình Khuyến Mãi",
                Size = new Size(400, 450),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            // Nhãn phần trăm
            Label lblPercent = new Label { Text = "Mức giảm giá (%):", AutoSize = true, Location = new Point(20, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

            // Ô nhập phần trăm (NumericUpDown)
            NumericUpDown numPercent = new NumericUpDown
            {
                Location = new Point(160, 23),
                Size = new Size(80, 25),
                Minimum = 1,
                Maximum = 99,
                Value = 20 // Mặc định 20%
            };

            // Nhãn chọn sản phẩm
            Label lblSelect = new Label { Text = "Chọn sản phẩm áp dụng:", AutoSize = true, Location = new Point(20, 70), Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

            // Danh sách Checkbox chứa tên các sản phẩm
            CheckedListBox chkProducts = new CheckedListBox
            {
                Location = new Point(20, 100),
                Size = new Size(340, 220),
                CheckOnClick = true
            };

            // Đọc tên sản phẩm từ Form gốc đưa vào CheckBoxList
            foreach (Control card in flpProducts.Controls)
            {
                PropertyInfo nameProp = card.GetType().GetProperty("ProductName");
                if (nameProp != null)
                {
                    string pName = nameProp.GetValue(card).ToString();
                    chkProducts.Items.Add(pName, true); // Thêm vào và tick chọn sẵn (true)
                }
            }

            // Nút Xác nhận áp dụng
            Button btnApply = new Button
            {
                Text = "Áp dụng Khuyến Mãi",
                Location = new Point(20, 340),
                Size = new Size(340, 45),
                BackColor = Color.FromArgb(232, 65, 24), // Đỏ cam
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnApply.FlatAppearance.BorderSize = 0;

            // 3. LOGIC KHI BẤM NÚT "ÁP DỤNG"
            btnApply.Click += (s, e) =>
            {
                if (chkProducts.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất 1 sản phẩm!", "Cảnh báo");
                    return;
                }

                decimal discountPercent = numPercent.Value;
                int countApplied = 0;

                // Duyệt qua các thẻ sản phẩm trên Form gốc
                foreach (Control card in flpProducts.Controls)
                {
                    PropertyInfo nameProp = card.GetType().GetProperty("ProductName");
                    PropertyInfo priceProp = card.GetType().GetProperty("ProductPrice");

                    if (nameProp != null && priceProp != null)
                    {
                        string pName = nameProp.GetValue(card).ToString();

                        // KIỂM TRA: Nếu sản phẩm này nằm trong danh sách đã được tick chọn thì mới giảm giá
                        if (chkProducts.CheckedItems.Contains(pName))
                        {
                            decimal oldPrice = (decimal)priceProp.GetValue(card);
                            decimal newPrice = oldPrice * (1m - (discountPercent / 100m));

                            // Ép giá trị mới vào thuộc tính của thẻ
                            priceProp.SetValue(card, newPrice);

                            // Đổi màu và chữ trên giao diện thẻ
                            foreach (Control child in card.Controls)
                            {
                                if (child is Label lbl && lbl.Text.Contains("đ"))
                                {
                                    lbl.Text = $"{newPrice:N0} đ (-{discountPercent}%)";
                                    lbl.ForeColor = Color.Red;
                                    break;
                                }
                            }
                            countApplied++;
                        }
                    }
                }

                MessageBox.Show($"Đã áp dụng giảm {discountPercent}% cho {countApplied} sản phẩm thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setupForm.Close(); // Đóng form cấu hình
            };

            // Ráp các thành phần vào Form cấu hình
            setupForm.Controls.Add(lblPercent);
            setupForm.Controls.Add(numPercent);
            setupForm.Controls.Add(lblSelect);
            setupForm.Controls.Add(chkProducts);
            setupForm.Controls.Add(btnApply);

            // Hiển thị Form cấu hình lên
            setupForm.ShowDialog();
        }
    }
}