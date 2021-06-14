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
namespace rentmall.pages.menA
{
    /// <summary>
    /// Логика взаимодействия для teantpag.xaml
    /// </summary>
    public partial class teantpag : Page
    {
        private int town_id;
        private int id;
        private int ten_id;
        private Frame mainframe;
        private ObservableCollection<town> all_towns;
        public delegate void refe();
        public event refe x;
        public teantpag(int Id, Frame frame, int ten_i)
        {
            InitializeComponent();
            id = Id;
            all_towns = town.pushtowns();
            towns_list.ItemsSource = all_towns;
            if (ten_i != 0)
            {
                ten_id = ten_i;
                tenod(ten_i);
            }
            else
            {
                all_towns.Add(new town { id = 0, name = "Не указано" });
                ten_id = 0;
                changbut.Content = "Создать";
                town_id = 0;
            }
            mainframe = frame;
        }
        private void tenod(int id)
        {
            tenant ten = tenant.pushtenant(id);
            namebox.Text = ten.name;
            addrbox.Text = ten.addres;
            phonebox.Text = ten.num;
            townbut.Content = ten.town;
            town_id = ten.town_id;
            ObservableCollection<town> i = new ObservableCollection<town>();
            foreach (town di in all_towns)
            {
                if (di.id != town_id) i.Add(di);
            }
            towns_list.ItemsSource = i;
        }

     

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            if (mainframe.CanGoBack)
            {
                mainframe.GoBack();
                mainframe.RemoveBackEntry();
            }
        }

        private void changbut_Click(object sender, RoutedEventArgs e)
        {
            if (cheak())
            {

                string strcon = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string cmd;
                    SqlCommand command;
                    if (ten_id != 0)
                    {
                        cmd = "exec dbo.update_tenant @id,@name,@addr,@phone,@town";
                        command = new SqlCommand(cmd, con);
                        command.Parameters.AddWithValue("@id", ten_id);
                    }
                    else
                    {
                        cmd = "exec dbo.new_tenant  @name,@addr,@phone,@town";
                        command = new SqlCommand(cmd, con);

                    }
                    command.Parameters.AddWithValue("@name", namebox.Text);
                    command.Parameters.AddWithValue("@addr", addrbox.Text);
                    command.Parameters.AddWithValue("@phone", phonebox.Text);
                    command.Parameters.AddWithValue("@town", town_id);
                    if (command.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Изменения успешны");
                        x();
                        mainframe.GoBack();
                        mainframe.RemoveBackEntry();

                    }
                }

            }
            else MessageBox.Show("erorr data");

        }
        private bool cheak()
        {
            bool b = true;
            if (namebox.Text == "Нет Значения" || namebox.Text == "") b = false;
            if (addrbox.Text == "Нет Значения" || addrbox.Text == "") b = false;
            if (phonebox.Text == "Нет Значения" || phonebox.Text == "") b = false;
            if (town_id == 0) b = false;
            return b;
        }

        private void townbut_Click(object sender, RoutedEventArgs e)
        {
            townspop.IsOpen = false;
            townspop.IsOpen = true;
        }

        private void towns_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (towns_list.SelectedItem != null)
            {
                town x = towns_list.SelectedItem as town;
                ObservableCollection<town> i = new ObservableCollection<town>();
                townbut.Content = x.name;
                foreach (town di in all_towns)
                {
                    if (di.id != x.id) i.Add(di);
                }
                towns_list.ItemsSource = i;
                town_id = x.id;
                townspop.IsOpen = false;
            }

        }

        private void rentbut_Click(object sender, RoutedEventArgs e)
        {
            allrenttenant pag = new allrenttenant(id, mainframe, ten_id);
            mainframe.Navigate(pag);
        }
    }
}
