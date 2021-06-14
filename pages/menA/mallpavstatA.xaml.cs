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

using rentmall.classi;
using rentmall.pages;
using System.Collections.ObjectModel;

using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.IO;
using System.Data;


namespace rentmall.pages.menA
{
    /// <summary>
    /// Логика взаимодействия для mallpavstatA.xaml
    /// </summary>
    public partial class mallpavstatA : Page
    {
        private Frame mainframe;
        private int id;
        ObservableCollection<mall> malli;
        public mallpavstatA(int Id, Frame frame)
        {
            InitializeComponent();

            id = Id;
            mainframe = frame;
            malli = mall.pushmalls();
            malls_list.ItemsSource = malli;
           // fill_table();
           // table.CanUserAddRows = false;
           //   table.CanUserDeleteRows = false;
        }
        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            if (mainframe.CanGoBack)
            {
                mainframe.GoBack();
                mainframe.RemoveBackEntry();


            }
        }

        private void townbut_Click(object sender, RoutedEventArgs e)
        {
            mallspop.IsOpen = false;
            mallspop.IsOpen = true;
        }

        private void malls_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (malls_list.SelectedItem != null)
            {
                mall x = malls_list.SelectedItem as mall;
                ObservableCollection<mall> i = new ObservableCollection<mall>();
                mallbut.Content = x.name;
                foreach (mall di in malli)
                {
                    if (di.id != x.id) i.Add(di);
                }
                malls_list.ItemsSource = i;
                mallspop.IsOpen = false;
                string constr = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    string cmd = "exec  dbo.All_mall_pav_stat " + x.id;
                    SqlCommand command = new SqlCommand(cmd, con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        name.Text = reader.GetString(0);
                        town.Text = reader.GetString(1);
                        pav_free.Text = reader.GetInt32(2).ToString();
                        pav_all.Text = reader.GetInt32(3).ToString();
                        pav_rent.Text = reader.GetInt32(4).ToString();
                        if (!reader.IsDBNull(5))
                            sqr.Text = reader.GetDouble(5).ToString();
                        else sqr.Text = "нет";
                        if (!reader.IsDBNull(6))
                            price.Text = reader.GetDecimal(6).ToString();
                        else price.Text = "нет";
                    }
                }
            }
        }
    }
}
