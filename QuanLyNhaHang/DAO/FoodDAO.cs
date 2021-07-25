using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetFoodByCategory(int id)
        {
            List<Food> listFood = new List<Food>();

            string query = "SELECT * FROM food WHERE id_cat = " + id + "";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }

        public List<Food> GetFood()
        {
            List<Food> listFood = new List<Food>();

            string query = "SELECT * FROM food ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }


        public bool InsertFood(string name, int idcat,int quantity, float price)
        {
            string query = string.Format("INSERT food (name, id_cat, quantity, price) VALUES (N'{0}', {1}, {2}, {3})", name, idcat, quantity, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }



        public bool UpdateFood(int id, string name, int idcat, int quantity, float price)
        {
            string query = string.Format("UPDATE food SET name=N'{0}', id_cat={1}, quantity={2}, price={3} WHERE id={4}", name, idcat, quantity, price,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }



        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(id);

            string query = "DELETE FROM `food` WHERE `food`.`id` = " +id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFoodByCatID(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByCatID(id);
            string query = "DELETE FROM `food` WHERE `food`.`id_cat` = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }



        public List<Food> SearchFood(string name)
        {
            List<Food> listFood = new List<Food>();

            string query = string.Format("SELECT * FROM food WHERE name LIKE N'%{0}%'",name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }


        public int CheckExistFood(string name)
        {
            string query = string.Format("SELECT COUNT(*) FROM food WHERE name = N'{0}'", name);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }

        public int CheckQuantity(int id)
        {
            string query = string.Format("SELECT quantity FROM food WHERE id = {0}", id);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }
    }
}
