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
    /// Логика взаимодействия для mallpageC.xaml
    /// </summary>
    public partial class mallpageC : Page
    {
        private int stat_id;
        private int town_id;
        private int mall_id;
        private int emp_id;
        private Frame mainframe;
        private ObservableCollection<town> all_towns;
        private ObservableCollection<mallstat> all_mallstats;
        private string img_path;
        public delegate void refe();
        public event refe x;
        public mallpageC(int id_emp, int id_mall, Frame frame)
        {

            InitializeComponent();
            img_path = "err";
            all_towns = town.pushtowns();

            towns_list.ItemsSource = all_towns;
            all_mallstats = mallstat.pushmallstats();

            emp_id = id_emp;
            stats_list.ItemsSource = all_mallstats;
            if (id_mall != 0)
            {
                malllod(id_mall);
                mall_id = id_mall;
                
            }
            else
            {
                all_towns.Add(new town { id = 0, name = "Не указано" });
                all_mallstats.Add(new mallstat { id = 0, name = "Не указано" });
                mall_id = id_mall;
                pavilgbut.IsEnabled = false;
                changbut.Content = "Создать";
                town_id = 0;
                stat_id = 0;
            }
            mainframe = frame;
        }
        private void malllod(int id_mall)
        {
            mall mal = mall.pushmall(id_mall);
            mall_name.Text = mal.name;
            coef.Text = mal.coef.ToString();
            stat_id = mal.state_id;
            town_id = mal.town_id;
            price.Text = mal.price.ToString();
            pic.Source = mal.pic;
            lvl.Text = mal.count_lvl.ToString();
            count_pavil.Text = mal.count_lvl.ToString();
            //ObservableCollection<mallstat> x = all_mallstats;
            ObservableCollection<mallstat> x = new ObservableCollection<mallstat>();
            foreach (mallstat d in all_mallstats)
            {
                if (d.id != stat_id) x.Add(d);
            }
            townbut.Content = mal.town;
            ObservableCollection<town> i = new ObservableCollection<town>();
            mall_stat.Content = mal.state;
            foreach (town di in all_towns)
            {
                if (di.id != town_id) i.Add(di);
            }
            stats_list.ItemsSource = x;
            towns_list.ItemsSource = i;


        }

        private void mall_stat_Click(object sender, RoutedEventArgs e)
        {
            stats.IsOpen = false;
            stats.IsOpen = true;
        }

        private void townbut_Click(object sender, RoutedEventArgs e)
        {
            townspop.IsOpen = false;
            townspop.IsOpen = true;
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
                    if (mall_id != 0)
                    {
                        cmd = "exec dbo.update_mall @mall_id,@name,@coef,@stat,@town,@price,@lvls,@pav,@image";
                        command = new SqlCommand(cmd, con);
                        command.Parameters.AddWithValue("@mall_id", mall_id);
                    }
                    else
                    {
                        cmd = "exec dbo.new_mall @name,@coef,@stat,@town,@price,@lvls,@pav,@image";
                        command = new SqlCommand(cmd, con);
                       
                    }
                    command.Parameters.AddWithValue("@name", mall_name.Text);
                    command.Parameters.AddWithValue("@coef", float.Parse(coef.Text));
                    command.Parameters.AddWithValue("@stat", stat_id);
                    command.Parameters.AddWithValue("@town", town_id);
                    command.Parameters.AddWithValue("@price", decimal.Parse(price.Text));
                    command.Parameters.AddWithValue("@lvls", int.Parse(lvl.Text));
                    command.Parameters.AddWithValue("@pav", int.Parse(count_pavil.Text));
                    command.Parameters.AddWithValue("@image", img_path);
                    try
                    {
                        if (command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("Изменения успешны");
                            x();
                            mainframe.GoBack();
                            mainframe.RemoveBackEntry();
                            //mainframe.Refresh();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка данных. У тц есть забронированные павильоны");
                    }
                }
                    
            }
            else MessageBox.Show("erorr data");
            
        }
        private bool cheak()
        {
            bool b = true;
            if (town_id == 0) b = false;
            if (stat_id == 0) b = false;
            if (mall_name.Text == "Нет Значения" || mall_name.Text == "") b = false;
            if (coef.Text == "Нет Значения"|| coef.Text == "" || !float.TryParse(coef.Text,out var n)) b = false;
            if (price.Text == "Нет Значения" || price.Text == "" || !decimal.TryParse(price.Text, out var p)) b = false;
            if (lvl.Text == "Нет Значения" || lvl.Text == "" || !byte.TryParse(lvl.Text, out var k)) b = false; 
            if (count_pavil.Text == "Нет Значения" || count_pavil.Text == "" || !int.TryParse(count_pavil.Text, out var ss)) b = false; 
            return b;
        }
        private void pavilgbut_Click(object sender, RoutedEventArgs e)
        {

            PavilsmallC pag = new PavilsmallC(mall_id, emp_id, mainframe);
            mainframe.Navigate(pag);
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

        private void stats_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(stats_list.SelectedItem != null)
            {
                mallstat x = stats_list.SelectedItem as mallstat;
                ObservableCollection<mallstat> i = new ObservableCollection<mallstat>();
                mall_stat.Content = x.name;
                foreach (mallstat d in all_mallstats)
                {
                    if (d.id != x.id) i.Add(d);
                }
                stats_list.ItemsSource = i;
                stat_id = x.id;
                stats.IsOpen = false;
            }
            
        }

        private void pic_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog() == true)
            {
                string ex = System.IO.Path.GetExtension(dialog.FileName);
                if (ex.Contains("png") || ex.Contains("jpg"))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(dialog.FileName);
                    image.EndInit();
                    pic.Source = image;
                    img_path = dialog.FileName;
                }
                else MessageBox.Show("Error");
            }
        }

        private void butpic_Click(object sender, RoutedEventArgs e)
        {
            pic_MouseRightButtonDown(null, null);
        }
    }
}
    
