using System;
using System.Collections.Generic;

namespace GUI_20212202_AXJ0GV.Client.Logic
{
    public interface IGameModel
    {
        string selectedShip { get; set; }
        bool IsThereASatellite { get; set; }
        bool GameOver { get; set; }
        double Angle { get; set; }
        event EventHandler Changed;
        List<Laser> Lasers { get; set; }
        List<Satellite> Satellites { get; set; }
        Satellite SatellitesAsPowerUp { get; set; }
        List<Asteroid> Asteroids { get; set; }
    }
}