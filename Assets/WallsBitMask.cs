using System;

namespace DescentHogFileReader
{
    [Flags]
    public enum WallsBitMask
    {
        SideLeft = 1,
        SideTop = 2,
        SideRight = 4,
        SideBottom = 8,
        SideBack = 16,
        SideFront = 32
    }
}
