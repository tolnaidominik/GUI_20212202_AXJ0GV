using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    //TODO  -> Armory (skin select, laser select) //levelup ship [LAST]
    //      -> Healthbar set (converter)
    //      -> Mission Select -- Change background -- Enemy (?)[LAST] 
    //      -> Leaderboard
    //      -> Sattelite implement // PlayerHP to 100, %rate to spawn, +XP //Time Duration bonus damage (30 sec bonus dmg) [LAST]
    //      -> Hitmarker, blow effect




    public class GameLogic : ObservableRecipient, IGameModel, IGameControl
    {
        private Asteroid selectedAsteroid;
        public bool IsMissionWindow { get; set; }
        public Asteroid SelectedAsteroid
        {
            get { return selectedAsteroid; }
            set { SetProperty(ref selectedAsteroid, value); }
        }
        public bool GameOver { get; set; }
        const int NUMOFASTEROIDS = 5;
        const int NUMOFSATELLITES = 12;
        public event EventHandler Changed;
        public Player Player { get; set; }
        Random rnd = new Random();
        public int GameTime { get; set; }

        public List<Player> playersForLb { get; set; }


        public enum Input
        {
            Left, Right, Down, Up, Rotate, Shoot
        }
        public enum GameItem
        {
            player, enemy, enemyBoss, asteroid, satellite
        }

        public int CompletedMissions { get; set; }
        public double Angle { get; set; }
        public List<Laser> Lasers { get; set; }
        public List<Asteroid> Asteroids { get; set; }
        public List<Satellite> Satellites { get; set; }
        public Satellite SatellitesAsPowerUp { get; set; }
        public bool IsThereASatellite {get; set;}
        public string selectedShip { get; set; }

        System.Windows.Size gameArea;
        public void SetUpSizes(System.Windows.Size area)
        {
            this.gameArea = area;
            
            Lasers = new List<Laser>();
            Asteroids = new List<Asteroid>();
            for (int i = 0; i < NUMOFASTEROIDS; i++)
            {
                Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height), 1));
            }

            Satellites = new List<Satellite>();
            for (int i = 0; i < NUMOFSATELLITES; i++)
            {
                Satellites.Add(new Satellite(new System.Windows.Size(gameArea.Width, gameArea.Height), i));
            }
          
        }

        public GameLogic() 
        {
            this.playersForLb = new List<Player>();
            this.Player = new Player();
            GameOver = false;
            GameTime = 0;
            CompletedMissions = 1;
        }

        public void Control(Input input)
        {
            switch (input)
            {
                case Input.Left:
                    Angle -= 5;
                    break;
                case Input.Right:
                    Angle += 5;
                    break;
                case Input.Up:
                    Angle = 0;
                    break;
                case Input.Down:
                    Angle = 180;
                    break;
                case Input.Rotate:
                    Angle += 180;
                    break;
                case Input.Shoot:
                    NewShot();
                    break;
                default:
                    break;
            }
            Changed?.Invoke(this, null);
        }

        private void NewShot()
        {
            double rad = (Angle - 90) * (Math.PI / 180);
            double dx = Math.Cos(rad);
            double dy = Math.Sin(rad);

            dx *= 25;
            dy *= 25;

            Lasers.Add(new Laser(new System.Drawing.Point((int)gameArea.Width /2, (int)gameArea.Height/2),
                new System.Windows.Vector(dx,dy)));
        }

        public void TimeStep()
        {
            if (!IsThereASatellite && rnd.Next(0, 1001) < 2)
            {
                SatellitesAsPowerUp = new Satellite(gameArea, rnd.Next(0, 4));
                IsThereASatellite = true;
            }
            
            selectedAsteroid = Asteroids[1];
            for (int i = 0; i < Lasers.Count; i++)
            {
                bool stillInside = Lasers[i].Move(new System.Drawing.Size(
                    (int)gameArea.Width, (int)gameArea.Height));
                if (!stillInside)
                {
                    Lasers.RemoveAt(i);
                }
            }

            for (int i = 0; i < Satellites.Count; i++)
            {
                Rect SatelliteRect = new Rect(Satellites[i].Center.X - 12, Satellites[i].Center.Y - 12, 35, 35);

                foreach (var shot in Lasers)
                {
                    Rect laserRect = new Rect(shot.Center.X - 3, shot.Center.Y - 3, 5, 5);

                    if (laserRect.IntersectsWith(SatelliteRect))
                    {
                        Satellites.RemoveAt(i);
                        if (Satellites.Count == 0)
                        {
                            GameOver = true;
                        }
                    }
                }
            }

            

            for (int i = 0; i < Asteroids.Count; i++)
            {
                bool inside = Asteroids[i].Move(new System.Drawing.Size((int)gameArea.Width, (int)gameArea.Height));
                if (!inside)
                {
                    var helpLevel = Asteroids[i].Level;
                    Asteroids.RemoveAt(i);
                    Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height), helpLevel));
                }
                else
                {
                    Rect asteroidRect = new Rect(Asteroids[i].Center.X - 12, Asteroids[i].Center.Y - 12, 25, 25);
                    Rect shipRect = new Rect(gameArea.Width / 2 - 25, gameArea.Height / 2 - 25, 50, 50);
                    if (!IsMissionWindow)
                    {
                        if (asteroidRect.IntersectsWith(shipRect))
                        {

                            if (Player.PlayerAlive)
                            {
                                Player.GetHit(this.Asteroids[i].Damage);
                                if (Player.Health <= 0)
                                {
                                    MessageBox.Show("YOU DIED!!!!LOLNOOBXD", "Die", MessageBoxButton.OK);
                                    GameOver = true;
                                    Player.Points += GameTime;
                                    File.AppendAllText("leaderboard.txt", String.Format($"{Player.Name}|{Player.Points}|{this.GameTime}" + Environment.NewLine));
                                }
                            }
                            var helpLevel = Asteroids[i].Level;
                            Asteroids.RemoveAt(i);
                            Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height), helpLevel));
                        }
                    }
                    foreach (var item in Lasers)
                    {
                        Rect laserRect = new Rect(item.Center.X - 3, item.Center.Y - 3, 5, 5);

                        if (IsThereASatellite)
                        {
                            Rect satRect = new Rect(SatellitesAsPowerUp.Center.X - 17, SatellitesAsPowerUp.Center.Y - 17, 35, 35);
                            if (laserRect.IntersectsWith(satRect))
                            {
                                SatellitesAsPowerUp = null;
                                Player.Health = 100;
                                Player.Points += 100;
                                IsThereASatellite = false;
                            }
                        }
                        

                        if (laserRect.IntersectsWith(asteroidRect))
                        {
                            if(Asteroids[i].Health > 0)
                            {
                                Asteroids[i].GetHit(this.Player.Damage);
                                if(Asteroids[i].Health <= 0)
                                {
                                    var helpLevel = Asteroids[i].Level;
                                    Asteroids.RemoveAt(i);
                                    Player.Xp += rnd.Next(10, 25);
                                    Player.Points += 10;
                                    Player.LevelUp();
                                    Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height), helpLevel));
                                }
                            }
                        }
                    }
                }
            }

            Changed?.Invoke(this, null);
        }
    }
}
