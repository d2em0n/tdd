using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using System.Reflection;
using System.Drawing;
using TagsCloudVisualization.Tests;


namespace TagsCloudVisualization
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        [TestCase(1, 2, TestName = "Odd coordinate value results in an even size value")]
        [TestCase(2, 5, TestName = "Even coordinate value results in an odd size value")]
        public void CircularCloudLayouter_MakeRightSizeLayout(int coordinateValue, int sizeValue)
        {
            var center = new Point(coordinateValue, coordinateValue);
            var size = new Size(sizeValue, sizeValue);

            var layout = new CircularCloudLayouter(center, new ArchemedianSpiral());

            layout.Size.Should().BeEquivalentTo(size);
        }

        [TestCase(-1, 1, TestName = "Negative X")]
        [TestCase(1, -1, TestName = "Negative Y")]
        [TestCase(0, 1, TestName = "Zero X")]
        [TestCase(1, 0, TestName = "Zero Y")]
        public void CircularCloudLayouter_GetsOnlyPositiveCenterCoordinates(int x, int y)
        {
            Action makeLayout = () => new CircularCloudLayouter(new Point(x, y), new ArchemedianSpiral());

            makeLayout.Should().Throw<ArgumentException>()
                .WithMessage("Center coordinates values have to be greater than Zero");
        }

        [Test]
        public void PutNextRectangle_ShouldKeepEnteredSize()
        {
            var layout = new CircularCloudLayouter(new Point(5, 5), new ArchemedianSpiral());
            var enteredSize = new Size(3, 4);
            var returnedSize = layout.PutNextRectangle(enteredSize).Size;

            returnedSize.Should().BeEquivalentTo(enteredSize);
        }

        [Test]
        public void PutNextRectangle_HasNotEnoughPoints()
        {
            
            var layout = new CircularCloudLayouter(new Point(100, 100), new TestPointGenerator());
            var rectangleSizes = new RandomSizeRectangle().GenerateRectangles(5);

            var makeRectangles = () => {
                foreach (var size in rectangleSizes)
                    layout.PutNextRectangle(size);
            };

            makeRectangles.Should().Throw<ArgumentException>()
                .WithMessage("Not Enough Points Generated");
        }
    }
}
