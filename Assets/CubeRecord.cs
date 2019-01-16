using Assets;

namespace DescentHogFileReader
{
    public class CubeRecord
    {
        public CubeBitMask CubeMask { get; set; }
        public int[] Children { get; set; } = new int[6];
        public int[] BoxVertices { get; set; } = new int[8];
        public EnergyCenter EnergyCenter { get; set; } = new EnergyCenter();
        public int LightValue { get; set; }
        public WallsBitMask WallsMask { get; set; }
        public Wall[] Sides { get; set; } = new Wall[6]; // wall numbers
    }
}
