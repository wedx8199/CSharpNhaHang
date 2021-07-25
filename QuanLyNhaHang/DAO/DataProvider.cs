using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuanLyNhaHang.DAO
{
    public class DataProvider
    {
        //singleton j đó
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }






        private string connectstr = "server=localhost;user id=root;database=nhahang;CharSet=utf8";
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable(); //tạo table để đổ data truy vấn từ sql vào
            using (MySqlConnection connection = new MySqlConnection(connectstr))
            {
            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection); //thực thi sql
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data); //fill table

            connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query)  //trả số dòng thực thi thành công
        {
            int data = 0; 
            using (MySqlConnection connection = new MySqlConnection(connectstr))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection); //thực thi sql
                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query)  //đếm số lượng trả ra, Vd trả ra cho count
        {
            object data = 0;
            using (MySqlConnection connection = new MySqlConnection(connectstr))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection); //thực thi sql
                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;
        }
    }
}
