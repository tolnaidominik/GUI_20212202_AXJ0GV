using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    //TODO  -> Armory (skin select, laser select)
    //      -> Level System to finish
    //      -> Healthbar set
    //      -> Mission Select
    //      -> Leaderboard
    //      -> Movement evolve (rotate)
    public class GameLogic : IGameModel, IGameControl
    {
        const int NUMOFASTEROIDS = 10;
        public event EventHandler Changed;
        public Player Player;
        public AsteroidStatistic Asteroid;
        Random rnd = new Random();


        public enum Input
        {
            Left, Right, Shoot
        }
        public enum GameItem
        {
            player, enemy, enemyBoss, asteroid, satellite
        }

        public double Angle { get; set; }
        public List<Laser> Lasers { get; set; }
        public List<Asteroid> Asteroids { get; set; }

        System.Windows.Size gameArea;
        public void SetUpSizes(System.Windows.Size area)
        {
            this.gameArea = area;
            
            Lasers = new List<Laser>();
            Asteroids = new List<Asteroid>();
            for (int i = 0; i < NUMOFASTEROIDS; i++)
            {
                Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height)));
            }
        }

        public GameLogic() 
        {
            this.Player = new Player();
            this.Asteroid = new AsteroidStatistic();
        }

        public void Control(Input input)
        {
            switch (input)
            {
                case Input.Left:
                    Angle -= 15;
                    break;
                case Input.Right:
                    Angle += 15;
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
            for (int i = 0; i < Lasers.Count; i++)
            {
                bool stillInside = Lasers[i].Move(new System.Drawing.Size(
                    (int)gameArea.Width, (int)gameArea.Height));
                if (!stillInside)
                {
                    Lasers.RemoveAt(i);
                }
            }

            for (int i = 0; i < Asteroids.Count; i++)
            {
                bool inside = Asteroids[i].Move(new System.Drawing.Size((int)gameArea.Width, (int)gameArea.Height));
                if (!inside)
                {
                    Asteroids.RemoveAt(i);
                    Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height)));
                }
                else
                {
                    Rect asteroidRect = new Rect(Asteroids[i].Center.X - 12, Asteroids[i].Center.Y - 12, 25, 25);
                    Rect shipRect = new Rect(gameArea.Width / 2 - 25, gameArea.Height / 2 - 25, 50, 50);
                    if (asteroidRect.IntersectsWith(shipRect))
                    {
                        Asteroids.RemoveAt(i);
                        if (Player.PlayerAlive)
                        {
                            Player.GetHit(this.Asteroids[i].Damage);
                        }
                        Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height)));
                    }

                    foreach (var item in Lasers)
                    {
                        Rect laserRect = new Rect(item.Center.X - 3, item.Center.Y - 3, 5, 5);

                        if (laserRect.IntersectsWith(asteroidRect))
                        {
                            if(Asteroids[i].Health > 0)
                            {
                                Asteroids[i].GetHit(this.Player.Damage);
                                if(Asteroids[i].Health <= 0)
                                {
                                    Asteroids.RemoveAt(i);
                                    Player.Xp += rnd.Next(10, 25);
                                    Player.LevelUp();
                                    Asteroids.Add(new Asteroid(new System.Windows.Size(gameArea.Width, gameArea.Height)));
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
