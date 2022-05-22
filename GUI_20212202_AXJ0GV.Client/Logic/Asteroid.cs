using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class Asteroid
    {
        public int Level { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        static Random rng = new Random();
        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }

        private int RNG(int min, int max)
        {
            int rnd;
            do
            {
                rnd = rng.Next(min, max + 1);
            } while (rnd == 0);
            return rnd;
        }

        public Asteroid(Size area)
        {
            this.Level = 1;
            this.Health = 10;
            this.Damage = 50;
            int vel = rng.Next(0, 4);
            switch (vel)
            {
                case 0:
                    Center = new System.Drawing.Point(rng.Next(25, (int)area.Width - 25), 25);
                    Speed = new Vector(RNG(-20, 20), RNG(1, 6));
                    break;
                case 1:
                    Center = new System.Drawing.Point(rng.Next(25, (int)area.Width - 25), (int)area.Height - 25);
                    Speed = new Vector(RNG(-20, 20), RNG(-20, -1));
                    break;
                case 2:
                    Center = new System.Drawing.Point(25, rng.Next(25, (int)area.Height - 25));
                    Speed = new Vector(RNG(0, 20), RNG(-20, 20));
                    break;
                case 3:
                    Center = new System.Drawing.Point((int)area.Width - 25, rng.Next(25, (int)area.Height - 25));
                    Speed = new Vector(RNG(-20, -1), RNG(-20, 6));
                    break;
                default:
                    break;
            }
        }
        public void LevelUp()
        {
            Level++;
            Health += 10;
            Damage += 1;
        }
        public bool Die()
        {
            return Health <= 0 ? true : false;
        }
        public void GetHit(int Damage)
        {
            Health -= Damage;
        }
        public bool Move(System.Drawing.Size area)
        {
            System.Drawing.Point newCenter =
                new System.Drawing.Point(Center.X + (int)Speed.X,
                Center.Y + (int)Speed.Y);
            if (newCenter.X >= 0 &&
                newCenter.X <= area.Width &&
                newCenter.Y >= 0 &&
                newCenter.Y <= area.Height
                )
            {
                Center = newCenter;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}