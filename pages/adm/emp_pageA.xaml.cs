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
    /// Логика взаимодействия для emp_pageA.xaml
    /// </summary>
    public partial class emp_pageA : Page
    {
        private int role_id;
        private int town_id;
        private int emp_id;
        private Frame mainframe;
        private string img_path;
        ObservableCollection<emprole> emproles;
        public delegate void refe();
        public event refe x;
        public emp_pageA(int id, Frame frame, int Emp_id)
        {
            InitializeComponent();
            img_path = "err";
            emproles = emprole.pushemproles();
            roles_list.ItemsSource = emproles;
            if (Emp_id != 0)
            {
               emp_id = Emp_id;
               emplod(Emp_id);
               
                
            }
            else
            {
                emproles.Add(new emprole { id = 0, name = "Не указано" });
                emp_id = 0;
                changbut.Content = "Создать";
                role_id = 0;
            }
            mainframe = frame;
        }
        private void emplod(int emp_i)
        {
            emp em = emp.pushemp(emp_i);
            namebox.Text = em.name;
            fambox.Text = em.fam;
            logbox.Text = em.log;
            patbox.Text = em.pat;
            passbox.Text = em.pass;
            if (em.gender == 'M') gend_but.Content = "Мужской";
            else gend_but.Content = "Женский";
            role_id = em.role_id;
            phonebox.Text = em.phonr;
            pic.Source = em.pic;
            ObservableCollection<emprole> x = new ObservableCollection<emprole>();
            foreach (emprole d in emproles)
            {
                if (d.id != role_id) x.Add(d);
            }
            role_but.Content = em.role;
            roles_list.ItemsSource = x;
        }

        private void gend_but_Click(object sender, RoutedEventArgs e)
        {
            genderpop.IsOpen = false;
            genderpop.IsOpen = true;
        }

        private void role_but_Click(object sender, RoutedEventArgs e)
        {
            rolepup.IsOpen = false;
            rolepup.IsOpen = true;
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
                    if (emp_id != 0)
                    {
                        cmd = "exec dbo.update_emp @emp_id,@name,@fam,@pat,@login,@passwors,@phone,@gender,@role_id,@image";
                        command = new SqlCommand(cmd, con);
                        command.Parameters.AddWithValue("@emp_id", emp_id);
                    }
                    else
                    {
                        cmd = "exec dbo.new_emp @name,@fam,@pat,@login,@passwors,@phone,@gender,@role_id,@image";
                        command = new SqlCommand(cmd, con);

                    }
                    command.Parameters.AddWithValue("@name", namebox.Text);
                    command.Parameters.AddWithValue("@fam", fambox.Text);
                    command.Parameters.AddWithValue("@pat", patbox.Text);
                    command.Parameters.AddWithValue("@login", logbox.Text);
                    command.Parameters.AddWithValue("@passwors", passbox.Text);
                    command.Parameters.AddWithValue("@phone", phonebox.Text);
                    if(gend_but.Content.ToString() == "Мужской") command.Parameters.AddWithValue("@gender", "M");
                    else command.Parameters.AddWithValue("@gender", "F");
                    command.Parameters.AddWithValue("@role_id", role_id);
                    command.Parameters.AddWithValue("@image", img_path);

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
            if (role_id == 0) b = false;
            if (namebox.Text == "Нет Значения" || namebox.Text == "") b = false;
            if (fambox.Text == "Нет Значения" || fambox.Text == "") b = false;
            if (patbox.Text == "Нет Значения" || patbox.Text == "") b = false;
            if (logbox.Text == "Нет Значения" || logbox.Text == "") b = false;
            if (passbox.Text == "Нет Значения" || passbox.Text == "") b = false;
            if (gend_but.Content.ToString() == "Нет Значения") b = false;
            if (phonebox.Text == "Нет Значения" || phonebox.Text == "") b = false;
            return b;
        }


        private void roles_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roles_list.SelectedItem != null)
            {
                emprole x = roles_list.SelectedItem as emprole;
                ObservableCollection<emprole> i = new ObservableCollection<emprole>();
                role_but.Content = x.name;
                foreach (emprole d in emproles)
                {
                    if (d.id != x.id) i.Add(d);
                }
                roles_list.ItemsSource = i;
                role_id = x.id;
                rolepup.IsOpen = false;
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

        private void male_but_Click(object sender, RoutedEventArgs e)
        {
            gend_but.Content = male_but.Content;
            genderpop.IsOpen = false;
        }

        private void female_but_Click(object sender, RoutedEventArgs e)
        {
            gend_but.Content = female_but.Content;
            genderpop.IsOpen = false;
        }
    }
}
