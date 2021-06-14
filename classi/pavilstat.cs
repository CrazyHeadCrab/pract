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
    class pavilstat
    {
        public int id { get; set; }
        public string name { get; set; }

        public static ObservableCollection<pavilstat> pushpavilstats()
        {
            ObservableCollection<pavilstat> pavstats = new ObservableCollection<pavilstat>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select state_name, state_id from pavilion_state ";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pavilstat x = new pavilstat();
                    x.id = reader.GetInt32(1);
                    x.name = reader.GetString(0);
                    pavstats.Add(x);
                }
            }
            return pavstats;
        }
    }
}
