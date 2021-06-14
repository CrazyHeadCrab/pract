using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;

namespace rentmall.classi
{
    class town
    {
        public int id { get; set; }
        public string name { get; set; }

        public static ObservableCollection<town> pushtowns()
        {
            ObservableCollection<town> towns = new ObservableCollection<town>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select town_name, town_id from town ";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    town x = new town();
                    x.id = reader.GetInt32(1);
                    x.name = reader.GetString(0);
                    towns.Add(x);
                }
            }
            return towns;
        }
    }
}
