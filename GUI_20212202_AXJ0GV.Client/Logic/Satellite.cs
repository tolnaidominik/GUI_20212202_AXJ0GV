using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class Satellite
    {
        static Random rng = new Random();
        public System.Drawing.Point Center { get; set; }

        public Satellite(Size gameArea, int index)
        {
            switch (index % 4)
            {
                case 0:
                    Center = new System.Drawing.Point(rng.Next(35, (int)gameArea.Width - 35), 
                        rng.Next(35, (int)gameArea.Height / 2 - 35));
                    break;
                case 1:
                    Center = new System.Drawing.Point(rng.Next(35, (int)gameArea.Width - 35), (int)gameArea.Height - 35);
                    break;
                case 2:
                    Center = new System.Drawing.Point(35, rng.Next(35, (int)gameArea.Height - 35));
                    break;
                case 3:
                    Center = new System.Drawing.Point((int)gameArea.Width - 35, rng.Next(35, (int)gameArea.Height - 35));
                    break;
                default:
                    break;
            }
        }
    }
}
