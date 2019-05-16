using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NewPostingsManager : BaseManager
    {
        public void CreateNewPostings(int CategoryId, string Title, double Price, string Adress, string Image, string Phone, string Email, string Description, int UserId)
        {
            SqlCommand komanda = new SqlCommand("INSERT INTO Postings(CategoryId, Title, Price, Adress, DateAdded, Phone, Email, Description, Image, UserId) VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", savienojums);

            DateTime DateAdded = DateTime.Now;
            komanda.Parameters.Add("@p1", SqlDbType.Int).Value = CategoryId;
            komanda.Parameters.Add("@p2", SqlDbType.NVarChar).Value = Title;
            komanda.Parameters.Add("@p3", SqlDbType.Decimal).Value = Price;
            komanda.Parameters.Add("@p4", SqlDbType.NVarChar).Value = Adress;
            komanda.Parameters.Add("@p5", SqlDbType.DateTime).Value = DateAdded;
            komanda.Parameters.Add("@p6", SqlDbType.VarChar).Value = Phone;
            komanda.Parameters.Add("@p7", SqlDbType.VarChar).Value = Email;
            komanda.Parameters.Add("@p8", SqlDbType.NVarChar).Value = Description;
            komanda.Parameters.Add("@p9", SqlDbType.VarChar).Value = Image;
            komanda.Parameters.Add("@p10", SqlDbType.Int).Value = UserId;
            komanda.ExecuteNonQuery();
        }
    }
}
