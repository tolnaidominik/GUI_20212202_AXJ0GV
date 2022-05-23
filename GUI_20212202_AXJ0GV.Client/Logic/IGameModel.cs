using System;
using System.Collections.Generic;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public interface IGameModel
    {
        bool GameOver { get; set; }
        double Angle { get; set; }
        event EventHandler Changed;
        List<Laser> Lasers { get; set; }
        List<Asteroid> Asteroids { get; set; }
    }
}