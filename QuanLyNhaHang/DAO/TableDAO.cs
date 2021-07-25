using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }




        public static int tableWidth = 100;
        public static int tableHeight = 100;
        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();


            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tablefood");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }

        public void ChangeStatusToFull(int id)
        {
            DataProvider.Instance.ExecuteQuery("UPDATE tablefood SET status = 'Có người' WHERE id= " + id);
        }


        public void ChangeStatusToEmpty(int id)
        {
            DataProvider.Instance.ExecuteQuery("UPDATE tablefood SET status = 'Trống' WHERE id= " + id);
        }


        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("UPDATE bill SET id_table = "+id2+" WHERE id_table = "+id1+" AND status = 0 ");
        }



        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT tablefood (name) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool DeleteTable(int id)
        {
            
            string query = string.Format("DELETE FROM `tablefood` WHERE `tablefood`.`id` = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTable(int id, string name)
        {
            string query = string.Format("UPDATE tablefood SET name=N'{0}' WHERE id={1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }



        public int CheckExistTable(int id)
        {
            string query = string.Format("SELECT COUNT(*) FROM bill WHERE id_table = {0}",id);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }

        public int CheckExistTableName(string name)
        {
            string query = string.Format("SELECT COUNT(*) FROM tablefood WHERE name = N'{0}'", name);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }
    }
}
