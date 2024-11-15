using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace TagsCloudVisualization
{
    [TestFixture]
    public class ArchemedianSpiral_Should
    {
        [Test]
        public void GeneratePoints_MovingAwayFromTheStart()
        {
            var start = new Point(0, 0);
            var points = new ArchemedianSpiral().GeneratePoints(start);
            var nearPoint = points.ElementAt(100);
            var farPoint = points.ElementAt(1000);

            DistanceBetween(start, nearPoint).Should().BeLessThan(DistanceBetween(start, farPoint));
        }

        public int DistanceBetween(Point start, Point destination)
        {
            return (int)(Math.Sqrt((start.X - destination.X) * (start.X - destination.X) +
                                   (start.Y - destination.Y) * (start.Y - destination.Y)));
        }
    }
}
