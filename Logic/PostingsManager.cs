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
    public class PostingsManager : BaseManager
    {
        public List<PostingsData> SelectAllPostingsByCategory(int categoryId)
        {
            string query = "SELECT * FROM Postings WHERE CategoryId = @p1 order by DateAdded desc";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.Int).Value = categoryId;
            SqlDataReader reader = komanda.ExecuteReader();

            List<PostingsData> result = new List<PostingsData>();
            while (reader.Read())
            {
                PostingsData data = new PostingsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.Title = Convert.ToString(reader["Title"]);
                data.Price = Convert.ToDouble(reader["Price"]);
                data.Address = Convert.ToString(reader["Adress"]);
                data.DateAdded = Convert.ToDateTime(reader["DateAdded"]);
                data.Phone = Convert.ToString(reader["Phone"]);
                data.Email = Convert.ToString(reader["Email"]);
                data.Descirption = Convert.ToString(reader["Description"]);
                data.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                data.UserId = Convert.ToInt32(reader["UserId"]);
                data.Image = Convert.ToString(reader["Image"]);
                result.Add(data);
            }

            reader.Close();

            return result;
        }

        public PostingsData SelectPostingById(int Id)
        {
            string query = "select * from postings where id = @p1 order by DateAdded desc";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.Int).Value = Id;

            SqlDataReader reader = komanda.ExecuteReader();

            reader.Read();
            PostingsData posting = new PostingsData();
            posting.Id = Convert.ToInt32(reader["Id"]);
            posting.Title = Convert.ToString(reader["Title"]);
            posting.Price = Convert.ToDouble(reader["Price"]);
            posting.Address = Convert.ToString(reader["Adress"]);
            posting.DateAdded = Convert.ToDateTime(reader["DateAdded"]);
            posting.Phone = Convert.ToString(reader["Phone"]);
            posting.Email = Convert.ToString(reader["Email"]);
            posting.Descirption = Convert.ToString(reader["Description"]);
            posting.Image = Convert.ToString(reader["Image"]);
            posting.CategoryId = Convert.ToInt32(reader["CategoryId"]);

            reader.Close();
            return posting;
        }

        public List<PostingsData> SelectAllPostingsByUserId(int UserId)
        {
            string query = "SELECT * FROM Postings WHERE UserId = @p1 order by DateAdded desc";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.Int).Value = UserId;
            SqlDataReader reader = komanda.ExecuteReader();

            List<PostingsData> result = new List<PostingsData>();
            while (reader.Read())
            {
                PostingsData data = new PostingsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.Title = Convert.ToString(reader["Title"]);
                data.Price = Convert.ToDouble(reader["Price"]);
                data.Address = Convert.ToString(reader["Adress"]);
                data.DateAdded = Convert.ToDateTime(reader["DateAdded"]);
                data.Phone = Convert.ToString(reader["Phone"]);
                data.Email = Convert.ToString(reader["Email"]);
                data.Descirption = Convert.ToString(reader["Description"]);
                data.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                data.UserId = Convert.ToInt32(reader["UserId"]);
                data.Image = Convert.ToString(reader["Image"]);
                result.Add(data);
            }

            reader.Close();

            return result;
        }

        public void DeletePostingById (int Id)
        {
            string query = "DELETE FROM Postings WHERE id = @p1";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.Int).Value = Id;
            komanda.ExecuteNonQuery();
        }

    }
}
