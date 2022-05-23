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
    /// Interaction logic for MissionSelectMenu.xaml
    /// </summary>
    public partial class MissionSelectMenu : Window
    {
        public MissionSelectMenu()
        {
            InitializeComponent();
            for (int i = 0; i < 25; i++)
            {
                Uniform_Grid.Children.Add(new Button() {
                    Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF180A3C"),
                    Foreground = Brushes.Wheat,
                    Name = $"button_{i}",
                    IsEnabled = false,
                    Content = i,
                    Padding = new Thickness(15),
                    Margin = new Thickness(20),
                    FontSize = 30,
                    FontWeight = FontWeights.ExtraBlack,
                });
            }
            setEnabled(0);
        }

        public void setEnabled(int index)
        {
            Button button = (Button)Uniform_Grid.Children[index];
            button.IsEnabled = true;
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _ = new MissionsWindow().ShowDialog();
        }
    }
}
