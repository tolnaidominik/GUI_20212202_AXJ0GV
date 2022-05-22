using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class Laser
    {
        public Laser(System.Drawing.Point center, Vector speed)
        {
            Center = center;
            Speed = speed;
        }

        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }
        
        public bool Move(System.Drawing.Size gameArea)
        {
            System.Drawing.Point newCenter = new(
                Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);

            if (newCenter.X >= 0 &&
                newCenter.X <= gameArea.Width &&
                newCenter.Y >= 0 &&
                newCenter.Y <= gameArea.Height)
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
