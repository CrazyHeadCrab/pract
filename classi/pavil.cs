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
    class pavil
    {
        public int id { get; set; }
        public string name { get; set; }
        

        public decimal price { get; set; }
        public byte lvl { get; set; }
        public float coef { get; set; }
        public string pav_stat { get; set; }
        public string mal_stat { get; set; }

        public int pav_state_id { get; set; }
        public int mal_stat_id { get; set; }

        public int mall_id { get; set; }
        public float sqer { get; set; }
        public string mal_name { get; set; }

        public static ObservableCollection<pavil> pushpavs( int id_mall)
        {
            ObservableCollection<pavil> pavs = new ObservableCollection<pavil>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select pavilion_name, mall_id, pav_state_id , lvl, squares,  price_per_one, coeficent_price, pavilion_id,pav_stat,mall_name,mall_stat_name,mall_stat_id  from dbo.All_pavil where mall_id ="+ id_mall;
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pavil x = new pavil();
                    x.mall_id = reader.GetInt32(1);
                    x.name = reader.GetString(0);
                    x.pav_state_id = reader.GetInt32(2);
                    x.sqer = float.Parse(reader.GetDouble(4).ToString());
                    x.price = reader.GetDecimal(5);
                    x.id = reader.GetInt32(7);
                    x.pav_stat = reader.GetString(8);
                    x.mal_name = reader.GetString(9);
                    x.mal_stat = reader.GetString(10);
                    x.mal_stat_id = reader.GetInt32(11);
                   
                    x.lvl = (byte)reader.GetInt32(3);
                    x.coef = float.Parse(reader.GetDouble(6).ToString());
                    pavs.Add(x);
                }
            }

            return pavs;
        }

        public static pavil pushpav(int id_pav)
        {
            pavil pav = new pavil();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select pavilion_name, mall_id, pav_state_id , lvl, squares,  price_per_one, coeficent_price, pavilion_id,pav_stat,mall_name,mall_stat_name,mall_stat_id  from dbo.All_pavil where pavilion_id =" + id_pav;
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    pav.mall_id = reader.GetInt32(1);
                    pav.name = reader.GetString(0);
                    pav.pav_state_id = reader.GetInt32(2);
                    pav.sqer = float.Parse(reader.GetDouble(4).ToString());
                    pav.price = reader.GetDecimal(5);
                    pav.id = reader.GetInt32(7);
                    pav.pav_stat = reader.GetString(8);
                    pav.mal_name = reader.GetString(9);
                    pav.mal_stat = reader.GetString(10);
                    pav.mal_stat_id = reader.GetInt32(11);

                    pav.lvl = (byte)reader.GetInt32(3);
                    pav.coef = float.Parse(reader.GetDouble(6).ToString());
                    
                }
            }

            return pav;
        }
    }
}
