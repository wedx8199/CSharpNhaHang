using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Category
    {
        public Category(int id, string name)
        {
            this.CateId = id;
            this.Name = name;
        }
        public Category(DataRow row)
        {
            this.CateId = (int)row["id"];
            this.Name = row["name"].ToString();
        }

        private int cateId;
        private string name;

        public int CateId { get => cateId; set => cateId = value; }
        public string Name { get => name; set => name = value; }
    }
}
