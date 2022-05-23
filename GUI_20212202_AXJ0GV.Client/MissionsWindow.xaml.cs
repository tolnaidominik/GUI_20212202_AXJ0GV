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
using System.Windows.Threading;
using static GUI_20212202_AXJ0GV.Client.Logic.GameLogic;

namespace GUI_20212202_AXJ0GV.Client
{
    /// <summary>
    /// Interaction logic for MissionsWindow.xaml
    /// </summary>
    public partial class MissionsWindow : Window
    {
        GameLogic gameLogic;
        public MissionsWindow()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
            displayMission.SetUpModel(gameLogic);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            displayMission.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            gameLogic.SetUpSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameLogic.TimeStep();
            if (gameLogic.GameOver)
            {
                MessageBox.Show("You cleared the satellites", "GRAT", MessageBoxButton.OK);
                gameLogic.CompletedMissions++;
                this.Close();
                gameLogic.GameOver = false;
                var window = new MissionSelectMenu();
                for (int i = 0; i < gameLogic.CompletedMissions; i++)
                {
                    window.setEnabled(i);
                }
                window.ShowDialog();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (gameLogic != null)
            {
                displayMission.SetupSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
                gameLogic.SetUpSizes(new Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                gameLogic.Control(Input.Left);
            }
            else if (e.Key == Key.Right)
            {
                gameLogic.Control(Input.Right);
            }
            else if (e.Key == Key.Up)
            {
                gameLogic.Control(Input.Up);
            }
            else if (e.Key == Key.Down)
            {
                gameLogic.Control(Input.Down);
            }
            else if (e.Key == Key.RightCtrl)
            {
                gameLogic.Control(Input.Rotate);
            }
            else if (e.Key == Key.RightAlt)
            {
                gameLogic.Control(Input.Shoot);
            }
        }
    }
}
