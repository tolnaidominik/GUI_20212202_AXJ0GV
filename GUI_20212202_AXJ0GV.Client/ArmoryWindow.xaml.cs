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
    /// Interaction logic for ArmoryWindow.xaml
    /// </summary>
    public partial class ArmoryWindow : Window
    {
        string ship = "player.png";
        public ArmoryWindow()
        {
            InitializeComponent();
            BitmapImage ship = new BitmapImage(new Uri(System.IO.Path.Combine("Renderer", "Images", "player.png"), UriKind.RelativeOrAbsolute));
            shipImg.Source = ship;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage ship = new BitmapImage(new Uri(System.IO.Path.Combine("Renderer", "Images", "player2.png"), UriKind.RelativeOrAbsolute));
            shipImg.Source = ship;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BitmapImage ship = new BitmapImage(new Uri(System.IO.Path.Combine("Renderer", "Images", "player.png"), UriKind.RelativeOrAbsolute));
            shipImg.Source = ship;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.ship = shipImg.Source.ToString().Split('/')[6];
            var menu = new MainWindowMenu();
            menu.setShip(ship);
            menu.Show();
        }
    }
}
