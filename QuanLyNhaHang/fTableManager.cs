using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using Menu = QuanLyNhaHang.DTO.Menu;

namespace QuanLyNhaHang
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAcc(loginAccount.Type); }
        }
        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

            LoadTableList();
            LoadCategory();
            LoadCBTable(cbSwitchTable);
            LoadDiscount();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Method
        void ChangeAcc(int type)
        {
            adminhToolStripMenuItem.Enabled = type == 1;
        }


        void LoadCategory()
        {
            List<Category> categorylist = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = categorylist;
            cbCategory.DisplayMember = "name";
        }
        void LoadFoodByCategory(int id)
        {
            List<Food> foodlist = FoodDAO.Instance.GetFoodByCategory(id);
            cbFood.DataSource = foodlist;
            cbFood.DisplayMember = "name";
        }
        void LoadDiscount()
        {
            cbDiscount.SelectedIndex = 0;
        }






        void LoadTableList()
        {
            flowLayoutPanelTable.Controls.Clear();
            List<Table> tablelist = TableDAO.Instance.LoadTableList();

            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.tableHeight, Height=TableDAO.tableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                /*if (item.Status == "Trống")
                {
                    btn.BackColor = Color.Aqua;
                }*/
                btn.Click += Btn_Click; //show hóa đơn của bàn
                btn.Tag = item; //trả về kiểu dữ liệu object

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flowLayoutPanelTable.Controls.Add(btn);
            }
        }


        void showBill(int id)
        {
            lisViewBill.Items.Clear();
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float TotalPrice = 0;
            foreach (Menu item in listBillInfo)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Quantity.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                TotalPrice += item.TotalPrice;

                lisViewBill.Items.Add(listViewItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN"); //đổi format sang của VN
            //txbTotalPrice.Text = TotalPrice.ToString();
            txbTotalPrice.Text = String.Format("{0:n0}", TotalPrice);

        }


        void LoadCBTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "name";
        }

        #endregion

        #region Events 

        private void Btn_Click(object sender, EventArgs e) //event show hóa đơn bàn
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lisViewBill.Tag = (sender as Button).Tag; //lưu cái table hiện tại vào tag để xuống dưới xài
            showBill(tableID);
        }


        private void ĐăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có chắc muốn đăng xuất?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }
        private void HóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReceipt fR = new fReceipt();
            fR.ShowDialog();
            this.Show();
        }


        private void ThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAP = new fAccountProfile(LoginAccount);
            fAP.ShowDialog();
        }

        private void AdminhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAD = new fAdmin();
            fAD.loginAccount = loginAccount; //vid 21 p18
            fAD.InsertFood += FAD_InsertFood;
            fAD.UpdateFood += FAD_UpdateFood;
            fAD.DeleteFood += FAD_DeleteFood;
            fAD.InsertCat += FAD_InsertCat;
            fAD.UpdateCat += FAD_UpdateCat;
            fAD.DeleteCat += FAD_DeleteCat;
            fAD.InsertTable += FAD_InsertTable;
            fAD.UpdateTable += FAD_UpdateTable;
            fAD.DeleteTable += FAD_DeleteTable;
            fAD.ShowDialog();
        }

        private void FAD_DeleteTable(object sender, EventArgs e)
        {
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
            LoadTableList();
        }

        private void FAD_UpdateTable(object sender, EventArgs e)
        {
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
            LoadTableList();
        }

        private void FAD_InsertTable(object sender, EventArgs e)
        {
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
            LoadTableList();
        }

        private void FAD_DeleteCat(object sender, EventArgs e)
        {
            LoadCategory();
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
            LoadTableList();
        }

        private void FAD_UpdateCat(object sender, EventArgs e)
        {
            LoadCategory();
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
        }

        private void FAD_InsertCat(object sender, EventArgs e)
        {
            LoadCategory();
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
        }

        private void FAD_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodByCategory((cbCategory.SelectedItem as Category).CateId);
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
                LoadTableList();
        }

        private void FAD_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodByCategory((cbCategory.SelectedItem as Category).CateId);
            if (lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
        }

        private void FAD_InsertFood(object sender, EventArgs e)
        {
            LoadFoodByCategory((cbCategory.SelectedItem as Category).CateId);
            if(lisViewBill.Tag != null)
                showBill((lisViewBill.Tag as Table).ID);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category selected = cb.SelectedItem as Category;
            id = selected.CateId;

            LoadFoodByCategory(id);
        }
        private void CbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Food selected = cb.SelectedItem as Food;
            id = selected.FoodId;



            if (FoodDAO.Instance.CheckQuantity(id) == 0)
            {
                MessageBox.Show(String.Format("Món {0} đã hết hàng", (cbFood.SelectedItem as Food).Name), "Thông báo", MessageBoxButtons.OK);
                btnAddFood.Enabled = false;
            }
            else
            {
                btnAddFood.Enabled = true;
            }
        }

        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lisViewBill.Tag as Table; //lấy ra table hiện tại
            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }
            int idBill = BillDAO.Instance.GetUnPaidBillByTableID(table.ID); //lấy id bill của table hiện tại
            int idFood = (cbFood.SelectedItem as Food).FoodId;
            int quantity = (int)numericUpDownFoodCount.Value;



            int idCat = (cbCategory.SelectedItem as Category).CateId;
            //int check = BillInfoDAO.Instance.CheckExistFood(idBill, idFood);


            if (MessageBox.Show(string.Format("{3}\nChọn món {0}\nĐơn giá: {1} vnđ\nSố lượng: {2}", (cbFood.SelectedItem as Food).Name, (cbFood.SelectedItem as Food).Price, quantity, table.Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if(FoodDAO.Instance.CheckQuantity(idFood) < quantity)
                {
                    MessageBox.Show(String.Format("Món {0} chỉ có số lượng là {1}", (cbFood.SelectedItem as Food).Name, FoodDAO.Instance.CheckQuantity(idFood)), "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                else if(idBill == -1) //nếu chưa có bill nào hết, tạo bill mới
                {
                BillDAO.Instance.InsertBill(table.ID,loginAccount.Id);
                BillInfoDAO.Instance.InsertBillInfo( BillDAO.Instance.GetMaxIDBill(), idFood , quantity, idCat);
                TableDAO.Instance.ChangeStatusToFull(table.ID); //status thành bàn có người
                }
                else if (BillInfoDAO.Instance.CheckExistFood(idBill, idFood) > 0)
                {
                    int defaultQuantity = BillInfoDAO.Instance.GetQuantity(idBill, idFood);
                    BillInfoDAO.Instance.UpdateQuantity(defaultQuantity, quantity,idBill, idFood);
                }
                else
                {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, quantity, idCat);
                }
            LoadCategory();
            showBill(table.ID);
            LoadTableList();
        }


        /*private void BtnDiscount_Click(object sender, EventArgs e)
        {
            Table table = lisViewBill.Tag as Table;
            float total1st = float.Parse(txbTotalPrice.Text);
            int discount = int.Parse(cbDiscount.SelectedItem.ToString());
            float total = total1st - (total1st/100) * discount;
            txbTotalPrice.Text = String.Format("{0:n0}", total);
            showBill(table.ID);
        }*/






        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lisViewBill.Tag as Table; //lấy ra table hiện tại
            int idBill = BillDAO.Instance.GetUnPaidBillByTableID(table.ID); //lấy id bill của table hiện tại
            float total = float.Parse(txbTotalPrice.Text);
            int discount = int.Parse(cbDiscount.SelectedItem.ToString());
            float totalFinal = total - ((total / 100) * discount);
            if (idBill == -1)
            {
                MessageBox.Show("Bàn đang trống", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if(MessageBox.Show(String.Format("Bạn có chắc muốn thanh toán {0} ?\n\n Tổng tiền phải thanh toán = {1} VNĐ", table.Name, String.Format("{0:n0}", totalFinal)),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, totalFinal, discount);
                    TableDAO.Instance.ChangeStatusToEmpty(table.ID); //status bàn trống
                    fPrint fP = new fPrint();
                    fP.IdBill = idBill;
                    fP.ShowDialog();
                    this.Show();  //showdialog phải đợi cho xog mới dc hiển thị lên lại
                    showBill(table.ID);
                    LoadTableList();
                }
            }

        }

        private void BtnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lisViewBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;

            if((cbSwitchTable.SelectedItem as Table).Status == "Trống")
            {
                if(MessageBox.Show(string.Format("Chuyển từ {0} sang {1} ?", (lisViewBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name),"Thông báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                TableDAO.Instance.SwitchTable(id1, id2);
                TableDAO.Instance.ChangeStatusToEmpty(id1);
                TableDAO.Instance.ChangeStatusToFull(id2);
                LoadTableList();
                }
            }
            else
            {
                MessageBox.Show(String.Format("Không thể chuyển bàn vì {0} đang có người", (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OK);
            }

        }





        #endregion


    }
}
