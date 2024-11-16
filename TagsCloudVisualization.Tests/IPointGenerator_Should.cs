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
    public class IPointGenerator_Should
    {
        [Test]
        public void GeneratePoints_MovingAwayFromTheStart()
        {
            GeneratePoints_MovingAwayFromTheStartFor(new ArchemedianSpiral());
            GeneratePoints_MovingAwayFromTheStartFor(new HeartShaped());
            GeneratePoints_MovingAwayFromTheStartFor(new DeltaSHaped());
        }

        [Test]
        public void GeneratePoints_ReturnsStartAsFirstPoint()
        {
            GeneratePoints_ReturnsStartAsFirstPointFor(new ArchemedianSpiral());
            GeneratePoints_ReturnsStartAsFirstPointFor(new HeartShaped());
            GeneratePoints_ReturnsStartAsFirstPointFor(new DeltaSHaped());
        }

        public void GeneratePoints_MovingAwayFromTheStartFor(IPointGenerator pointGenerator)
        {
            var start = new Point(0, 0);
            var points = pointGenerator.GeneratePoints(start); 
            var nearPoint = points.ElementAt(100);
            var farPoint = points.ElementAt(1000);

            DistanceBetween(start, nearPoint).Should().BeLessThan(DistanceBetween(start, farPoint));
        }
        public void GeneratePoints_ReturnsStartAsFirstPointFor(IPointGenerator pointGenerator)
        {
            var start = new Point(100, 100);
            var firstReturned = pointGenerator.GeneratePoints(start)
                .First();

            firstReturned.Should().BeEquivalentTo(start);
        }

        public int DistanceBetween(Point start, Point destination)
        {
            return (int)(Math.Sqrt((start.X - destination.X) * (start.X - destination.X) +
                                   (start.Y - destination.Y) * (start.Y - destination.Y)));
        }
    }
}
