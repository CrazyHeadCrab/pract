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
    /// Логика взаимодействия для allmallsC.xaml
    /// </summary>
    public partial class allmallsC : Page
    {
        private Frame mainframe;
        private ObservableCollection<mall> m;
        private int id;
        public allmallsC( int id1, Frame frame)
        {
            InitializeComponent();
            id = id1;
            mainframe = frame;
            ObservableCollection<mall> malls = mall.pushmalls();
            malllist.ItemsSource = malls;
            ObservableCollection<town> towns = town.pushtowns();
            towns.Add(new town { id = 0, name = "любой" });
            towns_list.ItemsSource = towns;
            ObservableCollection<mallstat> mallstats = mallstat.pushmallstats();
            mallstats.Add(new mallstat { id = 0, name = "любой" });
            stats_list.ItemsSource = mallstats;

            m = malls;
        }

        private void town_but_Click(object sender, RoutedEventArgs e)
        {
            townspop.IsOpen = false;
            townspop.IsOpen = true;
        }

        private void stat_but_Click(object sender, RoutedEventArgs e)
        {
            stats.IsOpen = false;
            stats.IsOpen = true;

        }

        private void towns_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (towns_list.SelectedItem != null)
            {
                town b = towns_list.SelectedItem as town;
                if (b.id == 0)
                {
                    malllist.ItemsSource = m;
                }
                else
                {
                    ObservableCollection<mall> x = new ObservableCollection<mall>();
                    foreach (mall a in m)
                    {
                        if (a.town.Contains(b.name)) x.Add(a);
                    }
                    malllist.ItemsSource = x;
                }
                
                town_but.Content = b.name;
                townspop.IsOpen = false;
                
            }
        }

        private void stats_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stats_list.SelectedItem != null)
            {
                mallstat b = stats_list.SelectedItem as mallstat;
                if (b.id == 0)
                {
                    malllist.ItemsSource = m;
                }
                else
                {
                    ObservableCollection<mall> x = new ObservableCollection<mall>();
                    foreach (mall a in m)
                    {
                        if (a.state.Contains(b.name)) x.Add(a);
                    }
                    malllist.ItemsSource = x;
                }

                stat_but.Content = b.name;
                stats.IsOpen = false;

            }
        }
        private bool town_cheak(mall mal)
        {
            mall b = towns_list.SelectedItem as mall;
            return mal.town.Contains(b.town);
        }



        private void malllist_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (malllist.SelectedItem != null)
            {
                popdel.IsOpen = false;
                popdel.IsOpen = true;

            }
        }

        private void malllist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mall b = (mall)malllist.Items[malllist.Items.IndexOf(((Border)sender).DataContext)];

            mallpageC pag = new mallpageC(id, b.id, mainframe);
            pag.x += re;
            mainframe.Navigate(pag);

            popdel.IsOpen = false;
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            mall b = malllist.SelectedItem as mall;
            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "update malls set state_id = 4 where mall_id = " + b.id;
                SqlCommand command = new SqlCommand(cmd, con);
                if (1 == command.ExecuteNonQuery())
                {
                    m = mall.pushmalls();
                    
                    malllist.ItemsSource = m;
                }
            }
            popdel.IsOpen = false;
        }

        private void new_mallbut_Click(object sender, RoutedEventArgs e)
        {
            mall b = malllist.SelectedItem as mall;
            mallpageC pag = new mallpageC(id, 0, mainframe);
            pag.x += re;
            mainframe.Navigate(pag);
        }
        private void re()
        {
            ObservableCollection<mall> malls = mall.pushmalls();
            malllist.ItemsSource = malls;
            m = malls;
        }
    }
}
