using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID,int idFoodCat, int quantity)
        {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.IdFoodCat = idFoodCat;
            this.Quantity = quantity;
        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["id_bill"];
            this.FoodID = (int)row["id_food"];
            this.IdFoodCat = (int)row["id_food_cat"];
            this.Quantity = (int)row["quantity"];
        }

        private int idFoodCat;
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int billID;
        public int BillID { get => billID; set => billID = value; }

        private int foodID;
        public int FoodID { get => foodID; set => foodID = value; }

        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }
        public int IdFoodCat { get => idFoodCat; set => idFoodCat = value; }
    }
}
