﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public interface IRectangleGenerator
    {
        IEnumerable<Size> GenerateRectangles(int quantity);
    }
}