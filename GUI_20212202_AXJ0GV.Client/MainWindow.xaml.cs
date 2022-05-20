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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static GUI_20212202_AXJ0GV.Client.Logic.GameLogic;

namespace GUI_20212202_AXJ0GV.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic gameLogic;
        public MainWindow()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
            display.SetUpModel(gameLogic);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameLogic.TimeStep();
        }

        private void Client_window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (gameLogic != null)
            {
                display.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
                gameLogic.SetUpSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            }
        }

        private void Client_window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                gameLogic.Control(Input.Left);
            }
            else if(e.Key == Key.Right)
            {
                gameLogic.Control(Input.Right);
            }
            else if (e.Key == Key.Space)
            {
                gameLogic.Control(Input.Shoot);
            }
        }

        private void Client_window_Loaded(object sender, RoutedEventArgs e)
        {
            display.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            gameLogic.SetUpSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    }
}