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
    class tenant
    {
        public int id { get; set; }
        public string name { get; set; }
        public int town_id { get; set; }
        public string addres { get; set; }
        public string num { get; set; }
        public string town { get; set; }
        public static ObservableCollection<tenant> pushtenants()
        {
            ObservableCollection<tenant> tenants = new ObservableCollection<tenant>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select rent_name, phone_number, addres,id_tenant, tenant.town_id, town_name from tenant inner join town on town.town_id = tenant.town_id ";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tenant x = new tenant();
                    x.id = reader.GetInt32(3);
                    x.name = reader.GetString(0);
                    x.num = reader.GetString(1);
                    x.addres = reader.GetString(2);
                    x.town_id = reader.GetInt32(4);
                    x.town = reader.GetString(5);
                    tenants.Add(x);
                }
            }
            return tenants;
        }
        public static tenant pushtenant(int id)
        {
            tenant tenan = new tenant();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select rent_name, phone_number, addres,id_tenant, tenant.town_id, town_name from tenant inner join town on town.town_id = tenant.town_id where id_tenant="+ id;
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    
                    tenan.id = reader.GetInt32(3);
                    tenan.name = reader.GetString(0);
                    tenan.num = reader.GetString(1);
                    tenan.addres = reader.GetString(2);
                    tenan.town_id = reader.GetInt32(4);
                    tenan.town = reader.GetString(5);
                }
            }
            return tenan;
        }

    }
}
