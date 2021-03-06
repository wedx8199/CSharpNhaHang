using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fPrintDT : Form
    {
        private string date1;

        public string Date1
        {
            get { return date1; }
            set { date1 = value; }
        }
        private string date2;

        public string Date2
        {
            get { return date2; }
            set { date2 = value; }
        }
        public fPrintDT()
        {
            InitializeComponent();
        }

        private void FPrintDT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nhahangDataSet6.GetDoanhThuByDate' table. You can move, or remove it, as needed.
            this.GetDoanhThuByDateTableAdapter.Fill(this.nhahangDataSet6.GetDoanhThuByDate,date1,date2);

            this.reportViewer1.RefreshReport();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Không xuất hóa đơn?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }
    }
}
