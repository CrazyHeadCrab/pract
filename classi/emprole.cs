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
    class emprole
    {
        public int id { get; set; }
        public string name { get; set; }

        public static ObservableCollection<emprole> pushemproles()
        {
            ObservableCollection<emprole> emproles = new ObservableCollection<emprole>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select role_name, role_id from emp_role ";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    emprole x = new emprole();
                    x.id = reader.GetInt32(1);
                    x.name = reader.GetString(0);
                    emproles.Add(x);
                }
            }
            return emproles;
        }
    }
}
