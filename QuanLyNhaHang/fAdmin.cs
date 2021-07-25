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
using MySql.Data.MySqlClient;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang
{
    public partial class fAdmin : Form
    {
        #region methods
        BindingSource foodlist = new BindingSource();
        BindingSource acclist = new BindingSource();
        BindingSource catlist = new BindingSource();
        BindingSource tablelist = new BindingSource();
        public Account loginAccount; //vid 21 p18
        public fAdmin()
        {
            
            InitializeComponent();
            dataGridViewFood.DataSource = foodlist;
            dataGridViewAccount.DataSource = acclist;
            dataGridViewCategory.DataSource = catlist;
            dataGridViewTable.DataSource = tablelist;
            LoadListFood();
            LoadListAcc();
            FoodBinding();
            AccBinding();
            LoadListCategory();
            CateBinding();
            LoadListTable();
            TableBinding();
            LoadCataCombobox(cbFoodCategory);
            //LoadAccList();
        }

        /*void LoadAccList()
        {
            string query = "SELECT id AS 'MaNV', fullname AS 'HoTen', username AS 'TenTK' FROM users";
            
            dataGridViewAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }*/





        void LoadListBillByDate(string date1, string date2)
        {
            dataGridViewBill.DataSource = BillDAO.Instance.ManageBill(date1, date2);
        }


        void LoadListFood()
        {
            foodlist.DataSource = FoodDAO.Instance.GetFood();
        }
        void FoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dataGridViewFood.DataSource, "name",true,DataSourceUpdateMode.Never));
            txbIDFood.DataBindings.Add(new Binding("Text", dataGridViewFood.DataSource, "FoodId", true, DataSourceUpdateMode.Never));
            numericUpDownFoodPrice.DataBindings.Add(new Binding("Value", dataGridViewFood.DataSource, "price", true, DataSourceUpdateMode.Never));
            numericUpDownQuantity.DataBindings.Add(new Binding("Value", dataGridViewFood.DataSource, "quantity", true, DataSourceUpdateMode.Never));
        }


        void LoadListAcc()
        {
            acclist.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AccBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "username", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "fullname", true, DataSourceUpdateMode.Never));
            cbTypeAccount.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
            cbGender.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "gender", true, DataSourceUpdateMode.Never));
            txbPhone.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "phone", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "email", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "address", true, DataSourceUpdateMode.Never));
            dateTimePickerBirthday.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "birthday", true, DataSourceUpdateMode.Never));
        }



        void LoadListCategory()
        {
            catlist.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void CateBinding()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dataGridViewCategory.DataSource, "CateId", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dataGridViewCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }


        void LoadListTable()
        {
            tablelist.DataSource = TableDAO.Instance.LoadTableList();
        }
        void TableBinding()
        {
            txbIDTable.DataBindings.Add(new Binding("Text", dataGridViewTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dataGridViewTable.DataSource, "name", true, DataSourceUpdateMode.Never));
        }




        void LoadCataCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }





        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFood(name);
            return listFood;
        }






        #endregion





        #region events
        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimePickerFromDate.Value.ToString("yyyyMMdd"), dateTimePickerToDate.Value.ToString("yyyyMMdd"));
        }

        private void BtnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }


        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private event EventHandler insertCat;
        public event EventHandler InsertCat
        {
            add { insertCat += value; }
            remove { insertCat -= value; }
        }
        private event EventHandler deleteCat;
        public event EventHandler DeleteCat
        {
            add { deleteCat += value; }
            remove { deleteCat -= value; }
        }
        private event EventHandler updateCat;
        public event EventHandler UpdateCat
        {
            add { updateCat += value; }
            remove { updateCat -= value; }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }





        private void TxbIDFood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewFood.SelectedCells.Count > 0)
                {
                    int id = (int)dataGridViewFood.SelectedCells[0].OwningRow.Cells["CatId"].Value;
                    Category category = CategoryDAO.Instance.GetCategoryById(id);

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.CateId == category.CateId)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }






        private void TxbFoodName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbFoodName.Text))
            {
                e.Cancel = true;
                txbFoodName.BackColor = Color.LightPink;
                errorProviderFoodName.SetError(this.txbFoodName, "Không được để trống tên món");
            }
            else
            {
                e.Cancel = false;
                txbFoodName.BackColor = Color.White;
                errorProviderFoodName.Clear();
            }
        }

        private void NumericUpDownQuantity_Validating(object sender, CancelEventArgs e)
        {
            
            if ((int)numericUpDownQuantity.Value >= 0)
            {
                e.Cancel = false;
                numericUpDownQuantity.BackColor = Color.White;
                errorProviderQuantity.Clear();
            }
            else
            {
                e.Cancel = true;
                numericUpDownQuantity.BackColor = Color.LightPink;
                errorProviderQuantity.SetError(this.numericUpDownQuantity, "Số lượng không được âm");
            }
        }

        private void NumericUpDownFoodPrice_Validating(object sender, CancelEventArgs e)
        {
            if ((int)numericUpDownFoodPrice.Value >= 1000)
            {
                e.Cancel = false;
                numericUpDownFoodPrice.BackColor = Color.White;
                errorProviderPrice.Clear();
            }
            else
            {
                e.Cancel = true;
                numericUpDownFoodPrice.BackColor = Color.LightPink;
                errorProviderPrice.SetError(this.numericUpDownFoodPrice, "Giá phải lớn hơn hoặc bằng 1000 VNĐ");
            }
        }



        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int catID = (cbFoodCategory.SelectedItem as Category).CateId;
            int quantity = (int)numericUpDownQuantity.Value;
            float price = (float)numericUpDownFoodPrice.Value;
            if (MessageBox.Show(string.Format("Bạn có chắc muốn thêm món mới {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (FoodDAO.Instance.CheckExistFood(name) > 0)
                {
                    MessageBox.Show("Không được thêm món đã có");
                    return;
                }
                else if (FoodDAO.Instance.InsertFood(name, catID, quantity, price))
            {
                    MessageBox.Show("Thêm món thành công!");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
                else
            {
                MessageBox.Show("Thêm món không thành công!");
            }
        }




        private void BtnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int catID = (cbFoodCategory.SelectedItem as Category).CateId;
            int quantity = (int)numericUpDownQuantity.Value;
            float price = (float)numericUpDownFoodPrice.Value;
            int id = Convert.ToInt32(txbIDFood.Text);
            if (MessageBox.Show(string.Format("Bạn có chắc muốn sửa thông tin món {0}?",name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (FoodDAO.Instance.UpdateFood(id, name, catID, quantity, price))
            {

                    MessageBox.Show("Sửa món thành công!");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Sửa món không thành công!");
            }
        }






        private void BtnDeleteFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int id = Convert.ToInt32(txbIDFood.Text);
            if (MessageBox.Show(string.Format("Bạn có chắc muốn xóa món {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa món không thành công!");
            }
        }






        private void BtnSearchFoodName_Click(object sender, EventArgs e)
        {
            foodlist.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }





        private void BtnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAcc();
        }



        private void TxbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbUserName.Text))
            {
                e.Cancel = true;
                txbUserName.BackColor = Color.LightPink;
                errorProviderUsername.SetError(this.txbUserName, "Không được bỏ trống");
            }
            else
            {
                e.Cancel = false;
                txbUserName.BackColor = Color.White;
                errorProviderUsername.Clear();
            }
        }

        private void TxbDisplayName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbDisplayName.Text))
            {
                e.Cancel = true;
                txbDisplayName.BackColor = Color.LightPink;
                errorProviderFullName.SetError(this.txbDisplayName, "Nhập đúng tên");
            }
            else
            {
                e.Cancel = false;
                txbDisplayName.BackColor = Color.White;
                errorProviderFullName.Clear();
            }
        }

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

        private void TxbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbAddress.Text))
            {
                e.Cancel = true;
                txbAddress.BackColor = Color.LightPink;
                errorProviderAddress.SetError(this.txbAddress, "Không được bỏ trống");
            }
            else
            {
                e.Cancel = false;
                txbAddress.BackColor = Color.White;
                errorProviderAddress.Clear();
            }
        }



        private void BtnAddAccount_Click(object sender, EventArgs e)
        {
            string name = txbUserName.Text;
            string fullname = txbDisplayName.Text;
            int type = int.Parse(cbTypeAccount.SelectedItem.ToString());
            string gender = cbGender.Text;
            string phone = txbPhone.Text;
            string email = txbEmail.Text;
            string address = txbAddress.Text;
            string birthday = dateTimePickerBirthday.Value.ToString("yyyyMMdd");
            if (MessageBox.Show(string.Format("Bạn có chắc muốn thêm tài khoản {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (AccountDAO.Instance.CheckExistName(name) > 0)
                {
                    MessageBox.Show("Không được thêm tài khoản đã có");
                    return;
                }
                else if (AccountDAO.Instance.InsertAccount(name, fullname, birthday, gender, phone, email, address, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadListAcc();
            }
                else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }

        private void BtnDeleteAccount_Click(object sender, EventArgs e)
        {
            string name = txbUserName.Text;
            if (MessageBox.Show(string.Format("Bạn có chắc muốn xóa tài khoản {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (loginAccount.Username.Equals(name))
            {
                MessageBox.Show("Ko dc xóa chính mình");
                return;
            }
                else if (AccountDAO.Instance.DeleteAccount(name))
            {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadListAcc();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
        }

        private void BtnEditAccount_Click(object sender, EventArgs e)
        {
            string name = txbUserName.Text;
            string fullname = txbDisplayName.Text;
            int type = int.Parse(cbTypeAccount.SelectedItem.ToString());
            string gender = cbGender.Text;
            string phone = txbPhone.Text;
            string email = txbEmail.Text;
            string address = txbAddress.Text;
            string birthday = dateTimePickerBirthday.Value.ToString("yyyyMMdd");
            if (MessageBox.Show(string.Format("Bạn có chắc muốn sửa thông tin {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                /*if (!loginAccount.Username.Equals(name))
                {
                    MessageBox.Show("Không được đổi tên đăng nhập");
                    return;
                }
                */
                
                /*else*/ if (AccountDAO.Instance.UpdateAccount(name, fullname, birthday, gender, phone, email, address, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
                LoadListAcc();
            }
                else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            string name = txbUserName.Text;
            if (MessageBox.Show(string.Format("Bạn có chắc muốn reset mật khẩu {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (AccountDAO.Instance.ResetPass(name))
            {
                MessageBox.Show("Reset mật khẩu tài khoản thành công");
                LoadListAcc();
            }
            else
            {
                MessageBox.Show("Reset mật khẩu tài khoản thất bại");
            }
        }





        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            if (MessageBox.Show(string.Format("Bạn có chắc muốn thêm danh mục {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (CategoryDAO.Instance.CheckExistCat(name) > 0)
                {
                    MessageBox.Show("Không được thêm danh mục đã có");
                    return;
                }
                else if (CategoryDAO.Instance.InsertCategory(name))
                {
                    MessageBox.Show("Thêm danh mục thành công");
                    LoadListCategory();
                    if (insertCat != null)
                        insertCat(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thất bại");
                }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = int.Parse(txbIDCategory.Text);
            if (MessageBox.Show(string.Format("Bạn có chắc muốn xóa danh mục {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (CategoryDAO.Instance.DeleteCategory(id))
                {
                    
                    MessageBox.Show("Xóa danh mục thành công");
                    LoadListCategory();
                    if (deleteCat != null)
                        deleteCat(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thất bại");
                }
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = int.Parse(txbIDCategory.Text);
            if (MessageBox.Show(string.Format("Bạn có chắc muốn sửa thành danh mục {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (CategoryDAO.Instance.UpdateCategory(id,name))
                {
                    MessageBox.Show("Sửa danh mục thành công");
                    LoadListCategory();
                    if (updateCat != null)
                        updateCat(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Sửa danh mục thất bại");
                }
        }




        private void BtnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            if (MessageBox.Show(string.Format("Bạn có chắc muốn thêm {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (TableDAO.Instance.CheckExistTableName(name) > 0)
                {
                    MessageBox.Show("Không được thêm bàn đã có");
                    return;
                }
                else if (TableDAO.Instance.InsertTable(name))
                {
                    MessageBox.Show("Thêm bàn thành công");
                    LoadListTable();
                    if (insertTable != null)
                        insertTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Thêm bàn thất bại");
                }
        }

        private void BtnDeleteTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            int id = int.Parse(txbIDTable.Text);
            if (MessageBox.Show(string.Format("Bạn có chắc muốn xóa {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (TableDAO.Instance.CheckExistTable(id) > 0)
                {
                    MessageBox.Show("Không được xóa bàn này vì có hóa đơn liên quan");
                    return;
                }
                else if (TableDAO.Instance.DeleteTable(id))
                {
                    MessageBox.Show("Xóa bàn thành công");
                    LoadListTable();
                    if (deleteTable != null)
                        deleteTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Xóa bàn thất bại");
                }
        }

        private void BtnEditTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            int id = int.Parse(txbIDTable.Text);
            if (MessageBox.Show(string.Format("Bạn có chắc muốn sửa thành {0}?", name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (TableDAO.Instance.UpdateTable(id, name))
                {
                    MessageBox.Show("Sửa bàn thành công");
                    LoadListTable();
                    if (updateTable != null)
                        updateTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Sửa bàn thất bại");
                }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePickerFromDate.Value.ToString("yyyyMMdd");
            string date2 = dateTimePickerToDate.Value.ToString("yyyyMMdd");
            if (MessageBox.Show(string.Format("Bạn muốn xuất doanh thu từ ngày {0} tới {1}?", dateTimePickerFromDate.Value.ToString("dd-MM-yyyy"), dateTimePickerToDate.Value.ToString("dd-MM-yyyy")), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                fPrintDT fPDT = new fPrintDT();
                fPDT.Date1 = date1;
                fPDT.Date2 = date2;
                fPDT.ShowDialog();
                this.Show();
            }
            else
            {
                return;
            }
        }








        #endregion

        private void FAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nhahangDataSet3.GetListBillByDateForReport' table. You can move, or remove it, as needed.
            this.GetListBillByDateForReportTableAdapter.Fill(this.nhahangDataSet3.GetListBillByDateForReport);
            // TODO: This line of code loads data into the 'nhahangDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.nhahangDataSet.users);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void cbTypeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
