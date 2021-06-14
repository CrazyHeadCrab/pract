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
    class mall
    {
        public int id { get; set; }
        public string name { get; set; }
        public BitmapSource pic { get; set; }

        public decimal price { get; set; }
        public byte count_lvl { get; set; }
        public float coef { get; set; }
        public string town { get; set; }
        public string state { get; set; }

        public int state_id { get; set; }
        public int town_id { get; set; }

        public static ObservableCollection<mall> pushmalls()
        {
            ObservableCollection<mall> malls = new ObservableCollection<mall>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select mall_id, mall_name, image , town_name, state_name,  count_pavilions, price, coeficent_price from dbo.all_malls";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mall x = new mall();
                    x.id = reader.GetInt32(0);
                    x.name = reader.GetString(1);
                    x.price = reader.GetDecimal(6);
                    x.town = reader.GetString(3);
                    x.state = reader.GetString(4);
                    x.count_lvl = (byte)reader.GetInt32(5);
                    x.coef = float.Parse(reader.GetDouble(7).ToString());
                    if (!reader.IsDBNull(2))
                    {
                        byte[] b = (byte[])reader[2];
                        var P = new BitmapImage();
                        using ( var stream = new MemoryStream(b))
                        {
                            stream.Position = 0;
                            P.BeginInit();
                            P.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            P.CacheOption = BitmapCacheOption.OnLoad;
                            P.UriSource = null;
                            P.StreamSource = stream;
                            P.EndInit();

                        }
                        P.Freeze();
                        x.pic = P;

                    }
                    malls.Add(x);
                }
            }

            return malls;
        }
        public static mall pushmall(int id)
        {
            mall mal = new mall();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select mall_id, mall_name, image , town_name, state_name,  count_pavilions, price, coeficent_price, state_id, town_id from dbo.all_malls where mall_id =" + id;
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                if  (reader.Read())
                {

                    mal.id = reader.GetInt32(0);
                    mal.name = reader.GetString(1);
                    mal.price = reader.GetDecimal(6);
                    mal.town = reader.GetString(3);
                    mal.state = reader.GetString(4);
                    mal.count_lvl = (byte)reader.GetInt32(5);
                    mal.coef = float.Parse(reader.GetDouble(7).ToString());
                    if (!reader.IsDBNull(2))
                    {
                        byte[] b = (byte[])reader[2];
                        var P = new BitmapImage();
                        using (var stream = new MemoryStream(b))
                        {
                            stream.Position = 0;
                            P.BeginInit();
                            P.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            P.CacheOption = BitmapCacheOption.OnLoad;
                            P.UriSource = null;
                            P.StreamSource = stream;
                            P.EndInit();

                        }
                        P.Freeze();
                        mal.pic = P;

                    }
                    mal.state_id = reader.GetInt32(8);
                    mal.town_id = reader.GetInt32(9);
                }
            }

            return mal;
        }


    }
}
