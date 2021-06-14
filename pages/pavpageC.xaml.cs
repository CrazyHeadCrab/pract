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
    /// Логика взаимодействия для pavpageC.xaml
    /// </summary>
    public partial class pavpageC : Page
    {
        private int stat_id;
        private int town_id;
        private int mall_id;
        private int pav_id;
        private int emp_id;
        private Frame mainframe;
        private ObservableCollection<pavilstat> all_pavstat;
        private string img_path;
        public delegate void refe();
        public event refe x;
        public pavpageC(int pav_i, int emp_i, int mall_i, Frame frame)
        {
            InitializeComponent();
            pav_id = pav_i;
            emp_id = emp_i;
            mall_id = mall_i;
            all_pavstat = pavilstat.pushpavilstats();
            stats_list.ItemsSource = all_pavstat;
            if (pav_id != 0)
            {
                pavlod(pav_id);
            }
            else
            {
                all_pavstat.Add(new pavilstat { id = 0, name = "Не указано" });

                changbut.Content = "Создать";
                stat_id = 3;
                pav_stat.Content = "Свободен";
            }
            mainframe = frame;
        }
        private void pavlod(int pavi)
        {
            pavil pav = pavil.pushpav(pavi);
            pav_name.Text = pav.name;
            coef.Text = pav.coef.ToString();
            stat_id = pav.pav_state_id;
            price.Text = pav.price.ToString();
            lvl.Text = pav.lvl.ToString();
            sqr_box.Text = pav.sqer.ToString() ;
            
            ObservableCollection<pavilstat> x = new ObservableCollection<pavilstat>();
            foreach (pavilstat d in all_pavstat)
            {
                if (d.id != stat_id) x.Add(d);
            }
            pav_stat.Content = pav.pav_stat;
            stats_list.ItemsSource = x;
        }

        private void mall_stat_Click(object sender, RoutedEventArgs e)
        {
            stats.IsOpen = false;
            stats.IsOpen = true;
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
                    if (pav_id != 0)
                    {
                        cmd = "exec dbo.update_pavil @pav_id,@name,@coef,@stat,@price,@lvl,@sqr";
                        command = new SqlCommand(cmd, con);
                        command.Parameters.AddWithValue("@pav_id", pav_id);
                    }
                    else
                    {
                        cmd = "exec dbo.new_pavilion  @mall_id,@name,@coef,@stat,@price,@lvl,@sqr";
                        command = new SqlCommand(cmd, con);
                        command.Parameters.AddWithValue("@mall_id", mall_id);
                    }
                    command.Parameters.AddWithValue("@name", pav_name.Text);
                    command.Parameters.AddWithValue("@coef", float.Parse(coef.Text));
                    command.Parameters.AddWithValue("@stat", stat_id);
                    command.Parameters.AddWithValue("@price", decimal.Parse(price.Text));
                    command.Parameters.AddWithValue("@lvl", int.Parse(lvl.Text));
                    command.Parameters.AddWithValue("@sqr", int.Parse(sqr_box.Text));
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
                        MessageBox.Show("Ошибка данных. Нельзя менять уже арендованные и забронированные павильоны");
                    }
                }

            }
            else MessageBox.Show("erorr data");

        }
        private bool cheak()
        {
            bool b = true;
            if (stat_id == 0) b = false;
            if (pav_name.Text == "Нет Значения" || pav_name.Text == "" || pav_name.Text.Length >4) b = false;
            if (coef.Text == "Нет Значения" || coef.Text == "" || !float.TryParse(coef.Text, out var n)) b = false;
            if (price.Text == "Нет Значения" || price.Text == "" || !decimal.TryParse(price.Text, out var p)) b = false;
            if (lvl.Text == "Нет Значения" || lvl.Text == "" || !byte.TryParse(lvl.Text, out var k)) b = false;
            if (sqr_box.Text == "Нет Значения" || sqr_box.Text == "" || !float.TryParse(sqr_box.Text, out var ss)) b = false;
            return b;
        }

        private void stats_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stats_list.SelectedItem != null)
            {
                pavilstat x = stats_list.SelectedItem as pavilstat;
                ObservableCollection<pavilstat> i = new ObservableCollection<pavilstat>();
                pav_stat.Content = x.name;
                foreach (pavilstat d in all_pavstat)
                {
                    if (d.id != x.id) i.Add(d);
                }
                stats_list.ItemsSource = i;
                stat_id = x.id;
                stats.IsOpen = false;
            }

        }

      
    }
}
