using GUI_20212202_AXJ0GV.Client.Logic;
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

namespace GUI_20212202_AXJ0GV.Client
{
    /// <summary>
    /// Interaction logic for MainWindowMenu.xaml
    /// </summary>
    public partial class MainWindowMenu : Window
    {
        string ship;
        public MainWindowMenu()
        {
            InitializeComponent();
        }

        public void setShip(string ship = "player.png")
        {
            this.ship = ship;
            ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var asd = new MainWindow();
            asd.setPlayerName(getPlayerName.Text);
            asd.setShip(this.ship);
            asd.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _ = new ArmoryWindow().ShowDialog();
            this.Close();
        }
    }
}
