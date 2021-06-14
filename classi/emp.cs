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
    class emp
    {
        public int id { get; set; }
        public string name { get; set; }
        public BitmapSource pic { get; set; }
        public string fam { get; set; }
        public string pat { get; set; }
        public string log { get; set; }
        public string phonr { get; set; }
        public char gender { get; set; }
        public string role { get; set; }
        public int role_id { get; set; }
        public string pass { get; set; }

        public static ObservableCollection<emp> pushemps()
        {
            ObservableCollection<emp> emps = new ObservableCollection<emp>();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select sur_name, name, login , pat_name, phone_number,  gender, emp_id, role_id,image,role_name from dbo.all_emp";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    emp x = new emp();
                    x.fam = reader.GetString(0);
                    x.name = reader.GetString(1);
                    x.log = reader.GetString(2);
                    x.pat = reader.GetString(3);
                    x.phonr = reader.GetString(4);
                    x.gender = reader.GetString(5)[0];
                    x.id = reader.GetInt32(6);
                    x.role_id = reader.GetInt32(7);
                    x.role = reader.GetString(9);
                    if (!reader.IsDBNull(8))
                    {
                        byte[] b = (byte[])reader[8];
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
                        x.pic = P;

                    }
                    emps.Add(x);
                }
            }

            return emps;
        }
        public static emp pushemp(int id)
        {
            emp em = new emp();

            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "select sur_name, name, login , pat_name, phone_number,  gender, emp_id, role_id,image,role_name,passwors  from dbo.all_emp where emp_id =" + id;
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    em.fam = reader.GetString(0);
                    em.name = reader.GetString(1);
                    em.log = reader.GetString(2);
                    em.pat = reader.GetString(3);
                    em.phonr = reader.GetString(4);
                    em.gender = reader.GetString(5)[0];
                    em.id = reader.GetInt32(6);
                    em.role_id = reader.GetInt32(7);
                    em.role = reader.GetString(9);
                    em.pass = reader.GetString(10);
                    if (!reader.IsDBNull(8))
                    {
                        byte[] b = (byte[])reader[8];
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
                        em.pic = P;

                    }
                }
            }

            return em;
        }
    }
}
