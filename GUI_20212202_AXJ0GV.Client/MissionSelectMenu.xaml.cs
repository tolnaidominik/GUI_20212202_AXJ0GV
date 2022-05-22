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
    /// Interaction logic for MissionSelectMenu.xaml
    /// </summary>
    public partial class MissionSelectMenu : Window
    {
        Button b = new Button();
        
        public MissionSelectMenu()
        {
            InitializeComponent();
            Thickness margin = b.Margin;
            margin.Left = 50;
            margin.Right = 50;
            margin.Top = 30;
            margin.Bottom = 30;
            b.Margin = margin;
            b.Background = Brushes.Tomato;
            b.Foreground = Brushes.White;
            Uniform_Grid.Columns = 5;
            Uniform_Grid.Rows = 5;
            b.Content = 1;
            Uniform_Grid.Children.Add(b);
        }
    }
}
