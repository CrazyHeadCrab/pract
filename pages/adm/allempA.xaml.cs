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
namespace rentmall.pages.adm
{
    /// <summary>
    /// Логика взаимодействия для allempA.xaml
    /// </summary>
    public partial class allempA : Page
    {
        private Frame mainframe;
        private ObservableCollection<emp> m;
        private int id;
        public allempA(int id1, Frame frame)
        {
            InitializeComponent();
            id = id1;
            mainframe = frame;
            ObservableCollection<emp>emps = emp.pushemps();
            emplist.ItemsSource = emps;
            
            m = emps;
        }



        private void emplist_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (emplist.SelectedItem != null)
            {
                popdel.IsOpen = false;
                popdel.IsOpen = true;

            }
        }

        private void emplist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            emp b = (emp)emplist.Items[emplist.Items.IndexOf(((Border)sender).DataContext)];

            emp_pageA pag = new emp_pageA(id, mainframe,b.id);
            pag.x += re;
            mainframe.Navigate(pag);

            popdel.IsOpen = false;
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            emp b = emplist.SelectedItem as emp;
            string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string cmd = "update emp set role_id = 4 where emp_id = " + b.id;
                SqlCommand command = new SqlCommand(cmd, con);
                if (1 == command.ExecuteNonQuery())
                {
                    m = emp.pushemps();

                    emplist.ItemsSource = m;
                }
            }
            popdel.IsOpen = false;
        }

        private void new_empbut_Click(object sender, RoutedEventArgs e)
        {
            emp_pageA pag = new emp_pageA(id, mainframe, 0);
            pag.x += re;
            mainframe.Navigate(pag);
        }
        private void re()
        {
            ObservableCollection<emp> emps = emp.pushemps();
            emplist.ItemsSource = emps;
            m = emps;
        }

        private void fam_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (fam_box.Text != "")
            {
                ObservableCollection<emp> emps = new ObservableCollection<emp>();
                foreach(emp em in m)
                {
                    if (em.fam.ToUpper().Contains(fam_box.Text.ToUpper())) emps.Add(em);
                }
                emplist.ItemsSource = emps;
            }
            else emplist.ItemsSource = m;
        }
    }
}
