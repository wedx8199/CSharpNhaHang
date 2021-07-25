using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        private BillInfoDAO() { }


        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM bill_info WHERE id_bill= "+ id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int billID, int foodID, int quantity,int idfoodcat)
        {
            DataProvider.Instance.ExecuteQuery("INSERT INTO `bill_info` (`id`, `id_bill`, `id_food`, `id_food_cat`, `quantity`) VALUES (NULL," + billID + " , "+ foodID + ", " + idfoodcat + ", " + quantity +")");
        }

        public int GetQuantity(int billID, int foodID)
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT quantity FROM bill_info WHERE id_bill = " + billID + " AND id_food = " + foodID);
        }

        public void UpdateQuantity(int quantity, int newquantity, int billID, int foodID)
        {
            DataProvider.Instance.ExecuteQuery("UPDATE bill_info SET quantity = " + (quantity + newquantity) + " WHERE id_bill = " + billID + " AND id_food = " + foodID);
        }

        public int CheckExistFood(int billID, int foodID)
        {
            string query = string.Format("SELECT COUNT(*) FROM bill_info WHERE id_bill = {0} AND id_food = {1}",billID,foodID);
            //return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM bill_info WHERE id_bill = " + billID + " AND id_food = " +foodID);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());
        }

        public void DeleteBillInfoByFoodID(int id) //xóa billinfo liên quan tới món vừa xóa
        {
            
            DataProvider.Instance.ExecuteQuery("DELETE FROM bill_info WHERE id_food = " + id);
        }
        public void DeleteBillInfoByCatID(int id) //xóa billinfo liên quan tới món vừa xóa
        {

            DataProvider.Instance.ExecuteQuery("DELETE FROM bill_info WHERE id_food_cat = " + id);
        }


    }
}
