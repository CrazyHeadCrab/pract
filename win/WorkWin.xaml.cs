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
using System.Windows.Shapes;
using rentmall.pages;
using rentmall.pages.menA;
using rentmall.pages.adm;
namespace rentmall.win
{
    /// <summary>
    /// Логика взаимодействия для WorkWin.xaml
    /// </summary>
    public partial class WorkWin : Window
    {
        public WorkWin(int id, int role)
        {

            InitializeComponent();
            switch (role)
            {
                case 1:
                    allempA pag = new allempA(id, mainframe);
                    mainframe.Navigate(pag);
                    break;
                case 2:
                    Alltenant pag1 = new Alltenant(id, mainframe);
                    mainframe.Navigate(pag1);
                    break;
                    
                case 3:
                    allmallsC allmalls = new allmallsC(id, mainframe);
                    mainframe.Navigate(allmalls);
                    break;
            }
        }
    }
}
