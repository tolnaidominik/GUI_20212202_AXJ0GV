﻿using GUI_20212202_AXJ0GV.Client.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_AXJ0GV.Client.Renderer
{
    public class Display : FrameworkElement
    {
        static Random rng = new Random();
        Size gameArea;

        IGameModel gameModel;

        public Brush BackgroundBrush { 
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri(
                Path.Combine("Renderer", "Images", "background.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush PlayerBrush
        {
            get
            {
                if(this.gameModel.selectedShip == null)
                {
                    return new ImageBrush(new BitmapImage(new Uri(
                    Path.Combine("Renderer", "Images", "player.png"), UriKind.RelativeOrAbsolute)));
                }
                else
                {
                    return new ImageBrush(new BitmapImage(new Uri(
                    Path.Combine("Renderer", "Images", this.gameModel.selectedShip), UriKind.RelativeOrAbsolute)));
                }
                
            }
        }
        public Brush SatelliteBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(
                Path.Combine("Renderer", "Images", "satellite1.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush PlayerLaserBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(
                Path.Combine("Renderer", "Images", "player_laser.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush AsteroidBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(
                Path.Combine("Renderer", "Images", "asteroid1.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public void SetUpModel(IGameModel model, string ship = "player.png")
        {
            this.gameModel = model;
            if(this.gameModel.selectedShip != null)
            {
                this.gameModel.selectedShip = ship;
            }
            this.gameModel.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public void SetupSizes(Size area)
        {
            this.gameArea = area;
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (gameModel != null && gameModel.Lasers != null)
            {
                //generate background image
                drawingContext.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, gameArea.Width, gameArea.Height));

                //generate player in the middle of the map
                drawingContext.PushTransform(new RotateTransform(gameModel.Angle, gameArea.Width / 2, gameArea.Height / 2));
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(gameArea.Width / 2 - 25, gameArea.Height / 2 - 25, 50, 50));
                drawingContext.Pop();

                //Name ->

                //generate shots
                foreach (var laser in gameModel.Lasers)
                {
                    drawingContext.DrawEllipse(PlayerLaserBrush, null, new Point(laser.Center.X, laser.Center.Y), 5, 5);
                }

                //generate asteroids
                foreach (var item in gameModel.Asteroids)
                {
                    drawingContext.DrawEllipse(AsteroidBrush, null, new Point(item.Center.X, item.Center.Y), 25, 25);
                }


                if (gameModel.SatellitesAsPowerUp != null)
                {
                    //generate satellite
                    drawingContext.DrawEllipse(SatelliteBrush, null, new Point(gameModel.SatellitesAsPowerUp.Center.X, gameModel.SatellitesAsPowerUp.Center.Y), 35, 35);
                }
                
                //foreach (Satellite satellite in gameModel.Satellites)
                //{
                //    drawingContext.DrawEllipse(SatelliteBrush, null, new Point(satellite.Center.X, satellite.Center.Y), 35, 35);
                //}
            }
        }
    }
}