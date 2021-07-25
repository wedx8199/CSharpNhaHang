using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }


        public int GetUnPaidBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM bill WHERE status = 0 AND id_table= " + id);
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1; //thành công sẽ trả về bill id, còn ko thì trả về -1(ko tồn tại)
        }

        public void InsertBill(int id,int billmaker)
        {
            DataProvider.Instance.ExecuteQuery(" INSERT INTO `bill` (`id`, `DateChecked`, `id_table`, `bill_maker`, `status`) VALUES (NULL, CURRENT_TIMESTAMP, "+ id + ", "+ billmaker +", '0') "); //chưa làm bill-maker
        }

        public int GetMaxIDBill() //trong trường hợp chưa có bill nào hết, phải thực hiện insertBill trc sau đó lấy số bill mới nhất = lấy max
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM bill");
        }

        public void CheckOut(int id, float total, int discount)
        {
            string query = "UPDATE bill SET status = 1, discount = "+ discount + " ,total = " + total + " WHERE id= " +id;
            DataProvider.Instance.ExecuteQuery(query);
        }


        public DataTable ManageBill(string date1, string date2)
        {
            string query = "SELECT b.id AS 'Mã hóa đơn',t.name AS 'Số bàn',b.total AS 'Tiền Thanh Toán (VNĐ)', b.discount AS 'Giảm giá (%)',b.DateChecked AS 'Ngày Lập Hóa Đơn' FROM bill AS b, tablefood AS t WHERE b.DateChecked BETWEEN " + date1 + " AND "+ date2 + "  AND b.status = 1 AND t.id = b.id_table";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public List<Bill> GetBill()
        {
            List<Bill> listBill = new List<Bill>();

            string query = "SELECT b.id,b.id_table,b.DateChecked,b.discount,b.total,b.status FROM bill AS b, tablefood AS t WHERE t.id = b.id_table ORDER BY b.DateChecked DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                listBill.Add(bill);
            }

            return listBill;
        }

        public DataTable GetBillDetail(string id)
        {
            string query = "SELECT f.name AS 'Tên món', f.price AS 'Đơn giá', bi.quantity AS 'Số lượng mua',f.price*bi.quantity AS 'Tổng (VNĐ)' FROM food AS f, bill_info AS bi WHERE f.id = bi.id_food AND bi.id_bill = " + id;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int CheckStatus(string id)
        {
            string query = string.Format("SELECT COUNT(*) FROM bill WHERE status = 0 AND id = {0}", id);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }

    }
}
