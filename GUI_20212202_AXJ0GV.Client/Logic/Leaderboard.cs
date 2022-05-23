using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class Leaderboard
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public string Time { get; set; }
        public Leaderboard(string name)
        {
            this.Name = name;
        }
    }
}
