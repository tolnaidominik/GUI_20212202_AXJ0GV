using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public class Player : ObservableObject
    {
        public string Name { get; set; }
        public int Level { get; set; }
        private int health;
        public int Health
        {
            get { return health; }
            set { SetProperty(ref health, value); }
        }

        public int Damage { get; set; }
        public bool PlayerAlive { get; set; }
        public int Xp{ get; set; }
        public double XpToLevelUp { get; set; }

        public Player()
        {
            this.PlayerAlive = true;
            this.Name = "Player";
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
                this.Damage = this.Level * 10;
                this.XpToLevelUp = this.Level * 147;
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
