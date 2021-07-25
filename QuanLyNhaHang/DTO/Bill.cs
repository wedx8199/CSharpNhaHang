using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? datecheck, int discount, float total, string status,int iDTable)
        {
            this.ID = id;
            this.DateCheck = datecheck;
            this.Discount = discount;
            this.Total = total;
            this.Status = status;
            this.IDTable = iDTable;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDTable = (int)row["id_table"];
            this.dateCheck = (DateTime?)row["DateChecked"];
            this.Discount = (int)row["discount"];
            this.Total = (float)Convert.ToDouble(row["total"].ToString());
            this.status = row["status"].ToString();
        }

        private float total;
        private int discount;
        private int iD;
        private int iDTable;
        public int ID { get => iD; set => iD = value; }
        public int IDTable { get => iDTable; set => iDTable = value; }

        private DateTime? dateCheck;
        public DateTime? DateCheck { get => dateCheck; set => dateCheck = value; }
        public int Discount { get => discount; set => discount = value; }
        public float Total { get => total; set => total = value; }

        private string status;
        public string Status { get => status; set => status = value; }
    }
}
