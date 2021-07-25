using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAcc(loginAccount); }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }


        //làm event đưa dữ liệu từ bên con sang bên cha (Load lại giá trị vừa sửa)
        private event EventHandler<AccountEvent> reloadAccount;
        public event EventHandler<AccountEvent> ReloadAccount
        {
            add { reloadAccount += value; }
            remove { reloadAccount -= value; }
        }
        public class AccountEvent : EventArgs
        {
            private Account acc;
            public Account Acc { get => acc; set => acc = value; }
            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }



        void ChangeAcc(Account acc)
        {
            txbUserName.Text = loginAccount.Username;
            txbDisplayName.Text = loginAccount.Fullname;
            txbPhone.Text = loginAccount.Phone;
            txbEmail.Text = loginAccount.Email;

        }


        /*private void TxbEmail_Leave(object sender, EventArgs e)
        {
            string pattern = @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txbEmail.Text, pattern))
            {
                errorProviderEmail.Clear();
            }
            else
            {
                errorProviderEmail.SetError(this.txbEmail, "Nhập đúng email");
            }
        }*/
        /*private void TxbPhone_Leave(object sender, EventArgs e)
        {
            string pattern = @"(09|01[2|6|8|9])+([0-9]{8})\b";
            if (Regex.IsMatch(txbPhone.Text, pattern))
            {
                errorProviderPhone.Clear();
            }
            else
            {
                errorProviderPhone.SetError(this.txbPhone, "Nhập đúng SĐT");
            }
        }*/
        private void TxbPhone_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"(09|01[2|6|8|9])+([0-9]{8})\b";
            if (Regex.IsMatch(txbPhone.Text, pattern))
            {
                e.Cancel = false;
                txbPhone.BackColor = Color.White;
                errorProviderPhone.Clear();
            }
            else
            {
                e.Cancel = true;
                txbPhone.BackColor = Color.LightPink;
                errorProviderPhone.SetError(this.txbPhone, "Nhập đúng SĐT");
            }
        }
        private void TxbEmail_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txbEmail.Text, pattern))
            {
                e.Cancel = false;
                txbEmail.BackColor = Color.White;
                errorProviderEmail.Clear();
            }
            else
            {
                e.Cancel = true;
                txbEmail.BackColor = Color.LightPink;
                errorProviderEmail.SetError(this.txbEmail, "Nhập đúng email");
            }
        }

        private void TxbDisplayName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbDisplayName.Text))
            {
                e.Cancel = true;
                txbDisplayName.BackColor = Color.LightPink;
                errorProviderName.SetError(this.txbDisplayName, "Nhập đúng tên");
            }
            else
            {
                e.Cancel = false;
                txbDisplayName.BackColor = Color.White;
                errorProviderName.Clear();
            }
        }






        void UpdateAcc()
        {
            string username = txbUserName.Text;
            string fullname = txbDisplayName.Text;
            string newpass = txbNewPass.Text;
            string reenterpass = txbReEnterPass.Text;
            string phone = txbPhone.Text;
            string email = txbEmail.Text;


            if (MessageBox.Show(string.Format("Bạn có chắc muốn thay đổi thông tin?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (!newpass.Equals(reenterpass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu khớp với mật khẩu mới!");
            }
                else if (txbNewPass.TextLength==0 || txbReEnterPass.TextLength == 0)
            {
                newpass = loginAccount.Password;
                reenterpass = loginAccount.Password;
                AccountDAO.Instance.ChangeInfoNoPass(username, fullname,reenterpass,phone,email);
                MessageBox.Show("Cập nhật thông tin thành công!");
                MessageBox.Show("Bạn cần đăng xuất để thông tin vừa cập nhật có hiệu lực!");
                    if (reloadAccount != null)
                    reloadAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                this.Close();
            }
                else
            {
                AccountDAO.Instance.ChangeInfo(username, fullname, reenterpass,phone,email);
                MessageBox.Show("Đã lưu mật khẩu mới!");
                if (reloadAccount != null)
                    reloadAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                this.Close();
            }
        }








        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có chắc muốn thoát?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            /*if(ValidateChildren(ValidationConstraints.Enabled))
            {
                UpdateAcc();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
            UpdateAcc();
        }

        private void lbUser_Click(object sender, EventArgs e)
        {

        }

        private void txbPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
