using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DAO;

namespace QuanLyNhaHang
{
    public partial class fReceipt : Form
    {
        BindingSource billtotallist = new BindingSource();
        BindingSource billlist = new BindingSource();
        public fReceipt()
        {
            InitializeComponent();
            dataGridViewBillTotal.DataSource = billtotallist;
            dataGridViewBillInfo.DataSource = billlist;
            LoadListBillTotal();
            IDBinding();
        }
        void LoadListBillTotal()
        {
            billtotallist.DataSource = BillDAO.Instance.GetBill();
        }
        void IDBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dataGridViewBillTotal.DataSource, "id", true, DataSourceUpdateMode.Never));
        }
        void LoadListBill(string id)
        {
            dataGridViewBillInfo.DataSource = BillDAO.Instance.GetBillDetail(id);
        }

        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            string id = txbID.Text;
            LoadListBill(id);

        }

        private void ButtonShowFood_Click(object sender, EventArgs e)
        {
            LoadListBillTotal();
            dataGridViewBillInfo.DataSource = null;

        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            string id = txbID.Text;
            int idBill = Int32.Parse(id);
            if (MessageBox.Show(string.Format("Bạn muốn in hóa đơn có mã là {0}?", id), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (BillDAO.Instance.CheckStatus(id) > 0)
                {
                    MessageBox.Show("Không được in hóa đơn chưa thanh toán!");
                    return;
                }
                else
                {
                    fPrint fP = new fPrint();
                    fP.IdBill = idBill;
                    fP.ShowDialog();
                    this.Show();  //showdialog phải đợi cho xog mới dc hiển thị lên lại
                }

        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có chắc muốn thoát?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();

        }
    }
}
