using GUI_20212202_AXJ0GV.Client.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_AXJ0GV.Client
{
    public class LeaderboardWindowViewModel
    {
        public LeaderboardItem LbItem{ get; set; }
        public List<LeaderboardItem> Leaderboard{ get; set; }
        public List<LeaderboardItem> sortedLeaderboard { get; set; }
        public LeaderboardWindowViewModel()
        {
            Leaderboard = new List<LeaderboardItem>();
            if (File.Exists("leaderboard.txt"))
            {
                ReadFile();
                this.sortedLeaderboard = Leaderboard.OrderByDescending(x => x.Points).ToList();
            }

        }
        private void ReadFile()
        {
            string[] adatok = File.ReadAllLines("leaderboard.txt");
            foreach (var item in adatok)
            {
                string name = item.Split('|')[0];
                int points = int.Parse(item.Split('|')[1]);
                int gametime = int.Parse(item.Split('|')[2]);
                Leaderboard.Add(new LeaderboardItem(name, points, gametime));
            }
        }
    }
}
