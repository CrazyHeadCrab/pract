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
using rentmall.pages.menA;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.IO;

namespace rentmall.pages.menA
{
    /// <summary>
    /// Логика взаимодействия для Alltenant.xaml
    /// </summary>
    public partial class Alltenant : Page
    {
        private Frame mainframe;
        private ObservableCollection<tenant> m;
        private int id;
        public Alltenant(int id1, Frame frame)
        {
            InitializeComponent();
            id = id1;
            mainframe = frame;
            ObservableCollection<tenant> tenants = tenant.pushtenants();
            tenantlist.ItemsSource = tenants;

            m = tenants;
        }

        private void tenantlist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tenant b = (tenant)tenantlist.Items[tenantlist.Items.IndexOf(((Border)sender).DataContext)];

            teantpag pag = new teantpag(id, mainframe, b.id);
            pag.x += re;
            mainframe.Navigate(pag);

        }

        

        private void new_empbut_Click(object sender, RoutedEventArgs e)
        {
            teantpag pag = new teantpag(id, mainframe, 0);
            pag.x += re;
            mainframe.Navigate(pag);
        }
        private void re()
        {
            ObservableCollection<tenant> tenants = tenant.pushtenants();
            tenantlist.ItemsSource = tenants;
            m = tenants;
        }

        private void name_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (name_box.Text != "")
            {
                ObservableCollection<tenant> tenants = new ObservableCollection<tenant>();
                foreach (tenant t in m)
                {
                    if (t.name.ToUpper().Contains(name_box.Text.ToUpper())) tenants.Add(t);
                }
                tenantlist.ItemsSource = tenants;
            }
            else tenantlist.ItemsSource = m;
        }

        private void mallstat_but_Click(object sender, RoutedEventArgs e)
        {
            mallstatA pag = new mallstatA(id, mainframe);
            mainframe.Navigate(pag);
        }

        private void mallstatpav_but_Click(object sender, RoutedEventArgs e)
        {
            mallpavstatA pag = new mallpavstatA(id, mainframe);
            mainframe.Navigate(pag);
        }
    }
}
