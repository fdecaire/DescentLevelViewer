using System;
using System.Collections.Generic;
using System.Text;

namespace DescentHogFileReader
{
    [Flags]
    public enum CubeBitMask
    {
        SideLeft = 1,
        SideTop = 2,
        SideRight = 4,
        SideBottom = 8,
        SideBack = 16,
        SideFront = 32,
        EnergyCenter = 64
    }
}
