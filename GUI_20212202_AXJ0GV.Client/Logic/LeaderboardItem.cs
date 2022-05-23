using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class LeaderboardItem
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int GameTime { get; set; }
        public LeaderboardItem(string name, int points, int gametime)
        {
            this.Name = name;
            this.Points = points;
            this.GameTime = gametime;
        }
    }
}
