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
    /// Логика взаимодействия для allrenttenant.xaml
    /// </summary>
    public partial class allrenttenant : Page
    {
        private Frame mainframe;
        private int id;
        private int ten_id;
        public allrenttenant(int Id, Frame frame, int ten_i)
        {
            InitializeComponent();
            id = Id;
            mainframe = frame;
            ten_id = ten_i;
            fill_table();
            table.CanUserAddRows = false;
            table.CanUserDeleteRows = false;
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            if (mainframe.CanGoBack)
            {
                mainframe.GoBack();
                mainframe.RemoveBackEntry();

                
            }
        }
        private void fill_table()
        {
            string constr = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string cmd = "exec dbo.all_rent_tenet " + ten_id;
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("rent");
                sqlData.Fill(dataTable);
                table.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
