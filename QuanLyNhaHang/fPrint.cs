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
    public partial class fPrint : Form
    {
        private int idBill;

        public int IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }
        public fPrint()
        {
            InitializeComponent();
        }

        private void FPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nhahangDataSet5.PrintBillInfoTotal' table. You can move, or remove it, as needed.
            this.PrintBillInfoTotalTableAdapter.Fill(this.nhahangDataSet5.PrintBillInfoTotal,idBill);
            // TODO: This line of code loads data into the 'nhahangDataSet4.PrintBillInfo' table. You can move, or remove it, as needed.
            this.PrintBillInfoTableAdapter.Fill(this.nhahangDataSet4.PrintBillInfo,idBill);


            this.reportViewer1.RefreshReport();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Không xuất hóa đơn?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }
    }
}
