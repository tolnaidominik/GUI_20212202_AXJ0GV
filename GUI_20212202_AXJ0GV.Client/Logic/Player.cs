using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class Player
    {
        public int Level { get; set; }
        public int Health{ get; set; }
        public int Damage { get; set; }
        public bool PlayerAlive { get; set; }
        public int Xp{ get; set; }
        public double XpToLevelUp { get; set; }

        public Player()
        {
            this.PlayerAlive = true;
            this.Level = 1;
            this.Health = 100;
            this.Damage = 10;
            this.Xp = 0;
            this.XpToLevelUp = 100;
        }

        public void LevelUp()
        {
            if (this.Xp >= this.XpToLevelUp)
            {
                Level++;
                this.Health += 10;
                this.Damage += 3;
                this.XpToLevelUp = this.Level * 150.268;
            }
        }
        public void GetHit(int Damage)
        {
            this.Health -= Damage;
            if(this.Health <= 0)
            {
                this.PlayerAlive = false;
            }
        }
    }
}
