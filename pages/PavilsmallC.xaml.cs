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

namespace rentmall.pages
{
    /// <summary>
    /// Логика взаимодействия для PavilsmallC.xaml
    /// </summary>
    public partial class PavilsmallC : Page
    {
        private Frame mainframe;
        private ObservableCollection<pavil> m;
        private int id;
        private int mall_id;
        private int emp_id;
        private int selct_pav;
        public PavilsmallC(int mall_i, int cli_id,Frame frame)
        {
            InitializeComponent();
            mainframe = frame;
            mall_id = mall_i;
            emp_id = cli_id;
            ObservableCollection<pavil> pavils = pavil.pushpavs(mall_id);
            pavlist.ItemsSource = pavils;
            ObservableCollection<pavilstat> pavilstats = pavilstat.pushpavilstats();
            pavilstats.Add(new pavilstat { id = 0, name = "любой" });
            stats_list.ItemsSource = pavilstats;
            m = pavils;
            ObservableCollection<tenant> tenants = tenant.pushtenants();
            tenats_list.ItemsSource = tenants;
        }

        private void stat_but_Click(object sender, RoutedEventArgs e)
        {
            stats.IsOpen = false;
            stats.IsOpen = true;

        }

        
        private void stats_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stats_list.SelectedItem != null)
            {
                pavilstat b = stats_list.SelectedItem as pavilstat;
                stat_but.Content = b.name;
                stats.IsOpen = false;

            }
        }


        private void pavlist_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (pavlist.SelectedItem != null)
            {
                pavil b = (pavil)pavlist.Items[pavlist.Items.IndexOf(((Border)sender).DataContext)];
                selct_pav = b.id;
                popdel.IsOpen = false;
                popdel.IsOpen = true;

            }
        }

        private void pavlist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pavil b = (pavil)pavlist.Items[pavlist.Items.IndexOf(((Border)sender).DataContext)];
            pavpageC pag = new pavpageC(b.id, emp_id, mall_id, mainframe);
            pag.x += re;
            mainframe.Navigate(pag);
            popdel.IsOpen = false;
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            pavil b = pavlist.SelectedItem as pavil;
            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "update pavilion set state_id = 4 where pavilion_id = " + b.id;
                SqlCommand command = new SqlCommand(cmd, con);
                if (1 == command.ExecuteNonQuery())
                {
                    m = pavil.pushpavs(mall_id);

                    pavlist.ItemsSource = m;
                }
            }
            popdel.IsOpen = false;
        }

        private void new_mallbut_Click(object sender, RoutedEventArgs e)
        {
            
            pavpageC pag = new pavpageC(0,emp_id,mall_id,mainframe);
            pag.x += re;
            mainframe.Navigate(pag);
        }
        private void re()
        {
            ObservableCollection<pavil> pavs = pavil.pushpavs(mall_id);

            pavlist.ItemsSource = pavs;
            m = pavs;
        }

        private void serch_but_Click(object sender, RoutedEventArgs e)
        {
            if (cheak())
            {
                ObservableCollection<pavil> pavils = new ObservableCollection<pavil>();
                foreach (pavil n in m)
                {
                    bool b = true;
                    if (lvlbox.Text != "")
                        if (n.lvl != byte.Parse(lvlbox.Text)) b = false;
                    if (sqrstbox.Text != "")
                        if(n.sqer < float.Parse(sqrstbox.Text)) b = false;
                    if (sqrendbox.Text != "")
                        if (n.sqer > float.Parse(sqrendbox.Text)) b = false;
                    if (b)pavils.Add(n);
                }
                pavlist.ItemsSource = pavils;
            }
            else MessageBox.Show("err");
        }
        private bool cheak()
        {
            bool b = true;
            float n, u;
            byte ss;
            if ((!float.TryParse(sqrstbox.Text,out n)&&n>=0) && sqrstbox.Text!="") b = false;
            if ((!float.TryParse(sqrendbox.Text, out  u) &&u>=n) && sqrendbox.Text != "") b = false;
            if ((!byte.TryParse(lvlbox.Text, out  ss))&& lvlbox.Text!="") b = false;
            return b;
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            if (mainframe.CanGoBack)
            {
                mainframe.GoBack();
                mainframe.RemoveBackEntry();
            }
        }

        private void new_pavbut_Click(object sender, RoutedEventArgs e)
        {
            pavpageC pag = new pavpageC(0, emp_id, mall_id, mainframe);
            pag.x += re;
            mainframe.Navigate(pag);
        }

        private void tenatbut_Click(object sender, RoutedEventArgs e)
        {
            tenats.IsOpen = false;
            tenats.IsOpen = true;
        }

        private void calend_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calend.SelectedDate != null)
            {
                dateendbut.Content = calend.SelectedDate.ToString();
                calendarendpop.IsOpen = false;
            }
            
        }

        private void calstart_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calstart.SelectedDate != null)
            {
                datestartbut.Content = calstart.SelectedDate.ToString();
                calendarstapop.IsOpen = false;
            }
        }

        private void dateendbut_Click(object sender, RoutedEventArgs e)
        {
            calendarendpop.IsOpen = false;
            calendarendpop.IsOpen = true;
        }

        private void datestartbut_Click(object sender, RoutedEventArgs e)
        {
            calendarstapop.IsOpen = false;
            calendarstapop.IsOpen = true;
        }

        private void tenats_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tenats_list.SelectedItem != null)
            {
                tenant b = tenats_list.SelectedItem as tenant;
                tenatbut.Content = b.name;
                tenats.IsOpen = false;
            }
        }

        private void arr_but_Click(object sender, RoutedEventArgs e)
        {
            poprent.IsOpen = false;
            poprent.IsOpen = true;
            datestartbut.Visibility = Visibility.Hidden;
            datestartbut.Content = null;
        }

        private void bron_but_Click(object sender, RoutedEventArgs e)
        {
            rent_name_block.Text = "Бронировать";
            poprent.IsOpen = false;
            poprent.IsOpen = true;
            datestartbut.Visibility = Visibility.Visible;
            
        }

        private void else_but_Click(object sender, RoutedEventArgs e)
        {
            rent_name_block.Text = "Арендовать";
            poprent.IsOpen = false;
            popdel.IsOpen = false;
            
        }

        private void rent_st_but_Click(object sender, RoutedEventArgs e)
        {
            poprent.IsOpen = false;
            popdel.IsOpen = false;
            if (cheak1())
            {
                string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    
                    con.Open();
                    string cmd;
                    SqlCommand command;
                    if (datestartbut.Visibility == Visibility.Visible)
                    {
                        cmd = "exec dbo.book_pav @ten_id,@emp_id,@dat_start,@dat_end,@pav_id";
                        command = new SqlCommand(cmd, con);
                        command.Parameters.AddWithValue("@dat_start", DateTime.Parse(datestartbut.Content.ToString()));
                    }
                    else
                    {
                        cmd = "exec dbo.rent_pav @ten_id,@emp_id,@dat_end,@pav_id";
                        command = new SqlCommand(cmd, con);
                    }
                    command.Parameters.AddWithValue("@ten_id", ((tenant)tenats_list.SelectedItem).id);
                    command.Parameters.AddWithValue("@emp_id", emp_id);
                    command.Parameters.AddWithValue("@dat_end", DateTime.Parse(dateendbut.Content.ToString()));
                    command.Parameters.AddWithValue("@pav_id", selct_pav);

                        if (command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("Изменения успешны");
                            re();
                            poprent.IsOpen = false;
                            popdel.IsOpen = false;
                        }


                }
            }
            else MessageBox.Show("Ошибка");

        }
        private bool cheak1()
        {
            bool b = true;
            if (datestartbut.Content == null && datestartbut.Visibility == Visibility.Visible) b = false;
            if (dateendbut.Content == null) b = false;
            if ( tenatbut.Content == null) b = false;
            return b;
        }
    }
}
