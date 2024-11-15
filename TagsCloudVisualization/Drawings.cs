using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    internal class Drawings
    {
        private static void Main()
        {
            var rectangleSizes = new RandomSizeRectangle().
                GenerateRectangles(300);
            var layout = new CircularCloudLayouter(new Point(1000, 1000));
            var image = new Bitmap(layout.Size.Width, layout.Size.Height);
            foreach (var size in rectangleSizes)
            {
                DrawRectangle(image, layout.PutNextRectangle(size));
                image.Save(@"c:\\Images\\1.bmp");
            }


            rectangleSizes = new RandomSizeRectangle().
                GenerateRectangles(300);
            var points = new HeartShaped().GeneratePoints(new Point(1000, 1000));
            layout = new CircularCloudLayouter(new Point(1000, 1000), points);
            image = new Bitmap(layout.Size.Width, layout.Size.Height);
            foreach (var size in rectangleSizes)
            {
                DrawRectangle(image, layout.PutNextRectangle(size));
                image.Save(@"c:\\Images\\2.bmp");
            }

            rectangleSizes = new RandomSizeRectangle().
                GenerateRectangles(300);
            //points = new DeltaSHaped().GeneratePoints(new Point(1000, 1000));
            layout = new CircularCloudLayouter(new Point(1000, 1000), new DeltaSHaped().GeneratePoints);
            image = new Bitmap(layout.Size.Width, layout.Size.Height);
            foreach (var size in rectangleSizes)
            {
                DrawRectangle(image, layout.PutNextRectangle(size));
                image.Save(@"c:\\Images\\3.bmp");
            }
        }

        //private static void DrawPicture(Func<int, IEnumerable<Size>> RectSizeGenerator, int quantity, 
        //    Func<Point, IEnumerable<Point>> ShapeGenerator, Point startPoint, string filename)
        //{
        //    if (ShapeGenerator == ArchemedianSpiral.)
        //}
        
        private static void DrawRectangle(Bitmap image, Rectangle rectangle)
        {
            var brush = new SolidBrush(GetRandomColor());
            var formGraphics = Graphics.FromImage(image);
            formGraphics.FillRectangle(brush, rectangle);
            brush.Dispose();
            formGraphics.Dispose();
        }

        private static Color GetRandomColor()
        {
            var random = new Random();
            return Color.FromArgb( random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
