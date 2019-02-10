using System;
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
        public int Length { get; set; }

        public CubeRecord(byte [] data, int offset)
        {
            var wallNameList = new[] {"Left", "Top", "Right", "Bottom", "Back", "Front"};
            Length = offset;

            CubeMask = (CubeBitMask)data[offset++];

            for (var j = 0; j < 6; j++)
            {
                Children[j] = -1;
            }

            // These are wall indexes.  If wall index == -2, then it is the special "end wall" at the end of the exit tunnel.
            for (var j = 0; j < 6; j++)
            {
                if (((int)CubeMask & (1 << j)) != 0)
                {
                    Children[j] = BitConverter.ToInt16(data, offset);
                    /*
                    if (Children[j] < -2 || Children[j] > cubeCount)
                    {
                        throw new AssertionException("Bad file format: Reference to a cube that does not exist.", "");
                    }
                    */
                    offset += 2;
                }
            }

            for (var j = 0; j < 8; j++)
            {
                BoxVertices[j] = BitConverter.ToInt16(data, offset);
                /*
                if (BoxVertices[j] < 0 || BoxVertices[j] > Vertices.Count)
                {
                    throw new AssertionException("Bad file format: Reference to a vertex that does not exist.", "");
                }
                */
                offset += 2;
            }

            // energy center
            if ((CubeMask & CubeBitMask.EnergyCenter) != 0)
            {
                EnergyCenter.Special = data[offset++];
                EnergyCenter.EnergyCenterNumber = data[offset++];
                EnergyCenter.Value = BitConverter.ToInt16(data, offset);
                offset += 2;
            }

            // static light
            LightValue = BitConverter.ToInt16(data, offset);
            offset += 2;

            WallsMask = (WallsBitMask)data[offset++];
            for (var j = 0; j < 6; j++)
            {
                Sides[j] = new Wall();
                Sides[j].WallName = wallNameList[j];
                if (((int)WallsMask & (1 << j)) != 0)
                {
                    Sides[j].Number = data[offset++];
                    if (Sides[j].Number == 255)
                    {
                        Sides[j].Number = -1;
                    }
                }
                else
                {
                    Sides[j].Number = -1;
                }
            }

            // read textures for each side
            for (var j = 0; j < 6; j++)
            {
                Sides[j].PrimaryTexture = -1;
                Sides[j].SecondaryTexture = -1;
                if (Children[j] == -1 || Sides[j].Number != -1)
                {
                    // primary texture
                    var primaryTexture = BitConverter.ToUInt16(data, offset);
                    Sides[j].PrimaryTexture = primaryTexture & 0x7fff;
                    offset += 2;
                    if ((primaryTexture & 0x8000) != 0)
                    {
                        // read the secondary texture
                        Sides[j].SecondaryTexture = BitConverter.ToInt16(data, offset);
                        offset += 2;
                    }

                    for (var k = 0; k < 4; k++)
                    {
                        //TODO: need to convert fixed point to float
                        Sides[j].Uvls[k] = new UVL
                        {
                            U = BitConverter.ToInt16(data, offset),
                            V = BitConverter.ToInt16(data, offset + 2),
                            L = BitConverter.ToInt16(data, offset + 4)
                        };
                        offset += 6;
                    }
                }
            }

            Length = offset - Length;
        }
    }
}
