using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class AccountDAO
    {
        //singleton j đó
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }



        public bool Login(string userName, string passWord)
        {   //crypt password
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }



            string query = "SELECT * FROM users WHERE username= N'" + userName + "' AND password= N'" + passWord + "' ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }


        public Account GetAccountByUserName(string username)
        {
            string query = "SELECT * FROM users WHERE username = '" + username+"' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public void ChangeInfo(string username, string fullname, string passWord, string phone, string email)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            DataProvider.Instance.ExecuteQuery("UPDATE users SET fullname = '" + fullname + "', password = N'"+hasPass+"', phone = '" + phone + "', email = '" + email + "' WHERE username = '" + username + "'");
        }

        public void ChangeInfoNoPass(string username, string fullname, string passWord, string phone, string email)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            DataProvider.Instance.ExecuteQuery("UPDATE users SET fullname = '" + fullname + "', password = N'" + passWord + "', phone = '" + phone + "', email = '" + email + "' WHERE username = '" + username + "'");
        }


        public DataTable GetListAccount()
        {
            string query = "SELECT fullname,birthday,gender,phone,email,address,username,type FROM users";
            return DataProvider.Instance.ExecuteQuery(query);
        }





        public bool InsertAccount(string name, string fullname, string birthday, string gender, string phone, string email, string address, int type)
        {
            string query = string.Format("INSERT users (username, fullname, birthday, gender, phone, email, address, type) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', {7})", name, fullname, birthday, gender, phone, email, address, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string fullname, string birthday, string gender, string phone, string email, string address, int type)
        {
            string query = string.Format("UPDATE users SET fullname=N'{1}', birthday=N'{2}', gender=N'{3}', phone=N'{4}', email=N'{5}', address=N'{6}', type={7} WHERE username=N'{0}'", name, fullname, birthday, gender, phone, email, address, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("DELETE FROM `users` WHERE `users`.`username` = N'{0}'",name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPass(string name)
        {
            string query = string.Format("UPDATE `users` SET password=N'20720532132149213101239102231223249249135100218' WHERE `users`.`username` = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }





        public int CheckExistName(string name)
        {
            string query = string.Format("SELECT COUNT(*) FROM users WHERE username = N'{0}'", name);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }
    }
}
