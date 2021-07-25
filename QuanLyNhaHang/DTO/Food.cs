using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Food
    {
        public Food(int f_id, string name, int cat_id, float price, int quantity)
        {
            this.FoodId = f_id;
            this.Name = name;
            this.CatId = cat_id;
            this.Price = price;
            this.Quantity = quantity;
        }
        public Food(DataRow row)
        {
            this.FoodId = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CatId = (int)row["id_cat"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.Quantity = (int)row["quantity"];
        }

        private int foodId;
        private string name;
        private int catId;
        private float price;
        private int quantity;

        public int FoodId { get => foodId; set => foodId = value; }
        public string Name { get => name; set => name = value; }
        public int CatId { get => catId; set => catId = value; }
        public float Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
