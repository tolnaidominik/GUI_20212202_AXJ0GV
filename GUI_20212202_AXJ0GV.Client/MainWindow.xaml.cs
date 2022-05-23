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
        public void setPlayerName(string playerName)
        {
            gameLogic.Player.Name = playerName;
            PlayerName.Content = playerName;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            gameLogic.TimeStep();
            healthBar.Value = gameLogic.Player.Health;
            Asteroid_Level.Content = gameLogic.SelectedAsteroid.Level;
            Asteroid_Health.Content = gameLogic.SelectedAsteroid.Health;
            Asteroid_Damage.Content = gameLogic.SelectedAsteroid.Damage;
            Player_Level.Content = gameLogic.Player.Level;
            Player_XP.Content = String.Format($"{gameLogic.Player.Xp}/{gameLogic.Player.XpToLevelUp}");
            Player_Damage.Content = gameLogic.Player.Damage;
            if(gameLogic.Player.Health >= 80)
            {
                healthBar.Foreground = Brushes.Green;
            }
            else if(gameLogic.Player.Health >= 30 && gameLogic.Player.Health < 80)
            {
                healthBar.Foreground = Brushes.Yellow;
            }
            else
            {
                healthBar.Foreground = Brushes.Red;
            }
            if (gameLogic.GameOver)
            {
                this.Close();
            }

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
            else if(e.Key == Key.Up)
            {
                gameLogic.Control(Input.Up);
            }
            else if (e.Key == Key.Down)
            {
                gameLogic.Control(Input.Down);
            }
            else if(e.Key == Key.RightCtrl)
            {
                gameLogic.Control(Input.Rotate);
            }
            else if (e.Key == Key.RightAlt)
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
                Interval = TimeSpan.FromMilliseconds(1)
            };
            DispatcherTimer timer2 = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(30)
            };
            DispatcherTimer timer3 = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
            timer2.Tick += Timer2_Tick;
            timer2.Start();
            timer3.Tick += Timer3_Tick;
            timer3.Start();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            gameLogic.gameTime++;
            Cock.Content = gameLogic.gameTime;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            foreach (Asteroid astreroid in gameLogic.Asteroids)
            {
                astreroid.LevelUp();
            }
        }
    }
}