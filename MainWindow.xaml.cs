using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using rentmall.win;

namespace rentmall
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
     
   
    public partial class MainWindow : Window
    {
        private int errr;
        public MainWindow()
        {
            InitializeComponent();
            errr = 0;
        }

        private void inbut_Click(object sender, RoutedEventArgs e)
        {
            if (errr >= 2 && capchacheak() || errr < 2)
            {
                string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string cmd = "select * from dbo.cheak_logpas(@log, @pas)";
                    SqlCommand sqlCommand = new SqlCommand(cmd, con);
                    sqlCommand.Parameters.AddWithValue("@log", loginbox.Text);
                    sqlCommand.Parameters.AddWithValue("@pas", pasbox.Password);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        int role = dataReader.GetInt32(1);
                        switch (role)
                        {
                            case 1:

                            case 2:

                            case 3:
                                WorkWin win = new WorkWin(id, role);
                                win.Show();
                                this.Close();
                                break;
                            case 4:
                                errblock.Text = "Аккаунт был удалён";
                                break;
                        }
                    }
                    else
                    {
                        errblock.Text = "Вы ввели некоректные данные";
                        errr++;
                        if (errr >= 2) capchaplus();
                    }
                }
            }
            else
            {
                errblock.Text = "Вы ввели неправильную капчу";
                capchaplus();
            }
        }
        private void capchaplus()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            x.Text = pwd;
            x.IsEnabled = false;
            capchstac.Visibility = Visibility.Visible;
        }
        private bool capchacheak()
        {
            return x.Text == capchbox.Text;
        }
    }
}
