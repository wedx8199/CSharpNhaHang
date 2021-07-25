using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Menu
    {
        public Menu(string foodname, int quantity, float price, float totalprice = 0)
        {
            this.FoodName = foodname;
            this.Quantity = quantity;
            this.Price = price;
            this.TotalPrice = totalprice;
        }

        public Menu(DataRow row)
        {
            this.FoodName = row["name"].ToString();
            this.Quantity = (int)row["quantity"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["total"].ToString());
        }



        private string foodName;
        private int quantity;
        private float price;
        private float totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
