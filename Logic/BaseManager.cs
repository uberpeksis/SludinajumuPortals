using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BaseManager
    {
        protected SqlConnection savienojums = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arturs\Desktop\C-sharp\SludinajumuPortals.mdf;Integrated Security=True;Connect Timeout=30");
        protected SqlCommand komanda;
        protected SqlDataAdapter adapter;
        protected DataSet data;

        public BaseManager()
        {
            savienojums.Open();
        }
    }
}
