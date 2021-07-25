using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Account
    {
        public Account(int id, string fullname, string username, string password, int type, string gender, string phone, string email, string address, DateTime? birthday)
        {
            this.Id = id;
            this.Fullname = fullname;
            this.Username = username;
            this.Password = password;
            this.Type = type;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.Birthday = birthday;
        }

        public Account(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Fullname = row["fullname"].ToString();
            this.Username = row["username"].ToString();
            this.Password = row["password"].ToString();
            this.Type = (int)row["type"];
            this.Gender = row["gender"].ToString();
            this.Phone = row["phone"].ToString();
            this.Email = row["email"].ToString();
            this.Address = row["address"].ToString();
            this.Birthday = (DateTime?)row["birthday"];

        }


        private int id;
        private string fullname;
        private string username;
        private string password;
        private int type;
        private string gender;
        private string phone;
        private string email;
        private string address;
        private DateTime? birthday;

        public string Fullname { get => fullname; set => fullname = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public DateTime? Birthday { get => birthday; set => birthday = value; }
        public int Id { get => id; set => id = value; }
    }
}
