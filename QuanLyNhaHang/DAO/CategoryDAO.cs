using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }



        public List<Category> GetListCategory()
        {
            List<Category> listCate = new List<Category>();

            string query = "SELECT * FROM categories";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCate.Add(category);
            }

            return listCate;
        }






        public Category GetCategoryById(int id)
        {
            Category category = null;
            string query = "SELECT * FROM categories WHERE id =" +id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }


        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT categories (name) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool DeleteCategory(int id)
        {
            FoodDAO.Instance.DeleteFoodByCatID(id);
            string query = string.Format("DELETE FROM `categories` WHERE `categories`.`id` = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateCategory(int id, string name)
        {
            string query = string.Format("UPDATE categories SET name=N'{0}' WHERE id={1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public int CheckExistCat(string name)
        {
            string query = string.Format("SELECT COUNT(*) FROM categories WHERE name = N'{0}'", name);
            return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());

        }
    }
}
