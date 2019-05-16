using Logic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CategoryManager : BaseManager
    {
        public List<CategoryData> SelectAllCategoriesForHomePage()
        {
            string query = "select c.*, (select count(*) from Postings p where p.CategoryId = c.Id) as Count from Categories c";
            komanda = new SqlCommand(query, savienojums);
            SqlDataReader reader = komanda.ExecuteReader();

            List<CategoryData> result = new List<CategoryData>();
            while (reader.Read())
            {
                CategoryData data = new CategoryData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.Title = Convert.ToString(reader["Title"]);
                if (reader["ParentCategoryId"] != DBNull.Value)
                {
                    data.ParentCategoryId = Convert.ToInt32(reader["ParentCategoryId"]);
                }
                data.Count = Convert.ToInt32(reader["Count"]);
                result.Add(data);
            }

            reader.Close();

            return result;

        }

        public List<CategoryData> SelectAllCategoriesForNewPostings()
        {
            List<CategoryData> data = new List<CategoryData>();
            komanda = new SqlCommand("SELECT * FROM Categories ORDER BY Id", savienojums);
            SqlDataReader reader = komanda.ExecuteReader();

            while (reader.Read())
            {
                CategoryData data2 = new CategoryData();
                data2.Id = Convert.ToInt32(reader["Id"]);
                data2.Title = Convert.ToString(reader["Title"]);
                if (reader["ParentCategoryId"] != DBNull.Value)
                {
                    data2.ParentCategoryId = Convert.ToInt32(reader["ParentCategoryId"]);
                }
                data.Add(data2);

                /*data.Add(new CategoryData()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = Convert.ToString(reader["Title"]),
                    ParentCategoryId = Convert.ToInt32(reader["ParentCategoryId"])
                }); */
            }
            reader.Close();
            return data;
        }

        public CategoryData SelectCategoryById(int Id)
        {
            string query = "SELECT * FROM Categories where id = @p1";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.Int).Value = Id;

            SqlDataReader reader = komanda.ExecuteReader();

            reader.Read();
            CategoryData category = new CategoryData();
            category.Id = Convert.ToInt32(reader["Id"]);
            category.Title = Convert.ToString(reader["Title"]);
            reader.Close();
            return category;
        }
    }

}
