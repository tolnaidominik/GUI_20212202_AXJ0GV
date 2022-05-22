using GUI_20212202_AXJ0GV.Client.Logic;
using System;
using System.Collections.Generic;
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
                return new ImageBrush(new BitmapImage(new Uri(
                Path.Combine("Renderer", "Images", "player.png"), UriKind.RelativeOrAbsolute)));
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

        public void SetUpModel(IGameModel model)
        {
            this.gameModel = model;
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

                ////generate satellites
                //ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(
                //    Path.Combine("Renderer", "Images", "satellite1.png"), UriKind.RelativeOrAbsolute)));
                //int count = rng.Next(1, 5);
                //for (int i = 0; i < count; i++)
                //{
                //    drawingContext.DrawEllipse(
                //        brush, null,
                //        new Point(rng.Next(0, (int)areaWidth), rng.Next(0, (int)areaHeight)),
                //        40, 40);
                //}
            }
        }
    }
}
