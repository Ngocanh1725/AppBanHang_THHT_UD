using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp
{
    public partial class PaymentForm : Form
    {
        // Nhận số tiền từ CheckoutForm truyền sang
        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            lblAmount.Text = $"{totalAmount:N0} VNĐ";
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Gán trạng thái OK báo hiệu người dùng đã thanh toán
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}
