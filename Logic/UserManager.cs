using Logic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserManager : BaseManager
    {
        public UserData SelectByUsernameAndPassword(string username, string password)
        {
            string query = "select * from Users where username = @p1 and [Password] = @p2";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.VarChar).Value = username;
            komanda.Parameters.Add("@p2", SqlDbType.VarChar).Value = _EncryptPassword(password);

            SqlDataReader reader = komanda.ExecuteReader();
            UserData user = null;

            if (reader.Read())
            {
                user = new UserData();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Username = Convert.ToString(reader["Username"]);
            }
            reader.Close();

            return user;

        }

        public void Create(string username, string password)
        {
            string query = "INSERT INTO users (Username, [Password]) VALUES (@p1, @p2)";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.VarChar).Value = username;
            komanda.Parameters.Add("@p2", SqlDbType.VarChar).Value = _EncryptPassword(password);
            komanda.ExecuteNonQuery();
        }

        public UserData SelectByUsername(string username)
        {
            string query = "select * from Users where Username = @p1";
            komanda = new SqlCommand(query, savienojums);
            komanda.Parameters.Add("@p1", SqlDbType.VarChar).Value = username;

            SqlDataReader reader = komanda.ExecuteReader();
            UserData user = null;

            if (reader.Read())
            {
                user = new UserData();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Username = Convert.ToString(reader["Username"]);
            }
            reader.Close();

            return user;
        }

        private string _EncryptPassword(string password)
        {
            byte[] hash = new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
    }
}
