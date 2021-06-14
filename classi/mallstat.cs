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
    class mallstat
    {
        public int id { get; set; }
        public string name { get; set; }

        public static ObservableCollection<mallstat> pushmallstats()
        {
            ObservableCollection<mallstat> mallstats = new ObservableCollection<mallstat>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select state_name, state_id from mall_state ";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mallstat x = new mallstat();
                    x.id = reader.GetInt32(1);
                    x.name = reader.GetString(0);
                    mallstats.Add(x);
                }
            }
            return mallstats;
        }
    }
}
