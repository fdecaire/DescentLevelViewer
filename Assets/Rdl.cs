using System;
using System.Collections.Generic;
using Assets;
using UnityEngine.Assertions;

//http://www.descent2.com/ddn/specs/rdl/
namespace DescentHogFileReader
{
    public class Rdl
    {
        public string Signature { get; set; }
        public int Version { get; set; }
        public int MineDataOffset { get; set; }
        public int ObjectsOffset { get; set; }
        public int FileSize { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<CubeRecord> Cubes { get; set; }

        public Rdl(HogFile hogFile)
        {
            char[] sig = { (char)hogFile.Data[0], (char)hogFile.Data[1], (char)hogFile.Data[2], (char)hogFile.Data[3] };

            Signature = new string(sig); //Should be LVLP

            Version = BitConverter.ToInt32(hogFile.Data, 4);
            MineDataOffset = BitConverter.ToInt32(hogFile.Data, 8);
            ObjectsOffset = BitConverter.ToInt32(hogFile.Data, 12);
            FileSize = BitConverter.ToInt32(hogFile.Data, 16);

            var ver = 0; // one byte for version
            var vertexCount = BitConverter.ToUInt16(hogFile.Data, MineDataOffset + 1);
            var cubeCount = BitConverter.ToUInt16(hogFile.Data, MineDataOffset + 3);

            Vertices = new List<Vertex>();

            var offset = MineDataOffset + 5;
            
            for (var i = 0; i < vertexCount; i++)
            {
                var vertexX = BitConverter.ToInt32(hogFile.Data, offset);
                offset += 4;

                var vertexY = BitConverter.ToInt32(hogFile.Data, offset);
                offset += 4;

                var vertexZ = BitConverter.ToInt32(hogFile.Data, offset);
                offset += 4;

                Vertices.Add(new Vertex
                {
                    X = vertexX / 65536.0,
                    Y = vertexY / 65536.0,
                    Z = vertexZ / 65536.0
                });
            }
            
            // load the cubes
            Cubes = new List<CubeRecord>();
            for (var i = 0; i < cubeCount; i++)
            {
                Cubes.Add(new CubeRecord());

                Cubes[Cubes.Count-1].CubeMask = (CubeBitMask)hogFile.Data[offset++];

                for (var j = 0; j < 6; j++)
                {
                    Cubes[Cubes.Count - 1].Children[j] = -1;
                }

                // These are wall indexes.  If wall index == -2, then it is the special "end wall" at the end of the exit tunnel.
                for (var j = 0; j < 6; j++)
                {
                    if (((int) Cubes[Cubes.Count - 1].CubeMask & (1 << j)) != 0)
                    {
                        Cubes[Cubes.Count - 1].Children[j] = BitConverter.ToInt16(hogFile.Data, offset);

                        if (Cubes[Cubes.Count - 1].Children[j] < -2 || Cubes[Cubes.Count - 1].Children[j] > cubeCount)
                        {
                            throw new AssertionException("Bad file format: Reference to a cube that does not exist.","");
                        }
                        offset += 2;
                    }
                }

                for (var j = 0; j < 8; j++)
                {
                    Cubes[Cubes.Count - 1].BoxVertices[j] = BitConverter.ToInt16(hogFile.Data, offset);

                    if (Cubes[Cubes.Count - 1].BoxVertices[j] < 0 || Cubes[Cubes.Count - 1].BoxVertices[j] > Vertices.Count)
                    {
                        throw new AssertionException("Bad file format: Reference to a vertex that does not exist.","");
                    }

                    offset += 2;
                }

                // energy center
                if ((Cubes[Cubes.Count - 1].CubeMask & CubeBitMask.EnergyCenter) != 0)
                {
                    Cubes[Cubes.Count - 1].EnergyCenter.Special = hogFile.Data[offset++];
                    Cubes[Cubes.Count - 1].EnergyCenter.EnergyCenterNumber = hogFile.Data[offset++];
                    Cubes[Cubes.Count - 1].EnergyCenter.Value = BitConverter.ToInt16(hogFile.Data, offset);
                    offset += 2;
                }

                // static light
                Cubes[Cubes.Count - 1].LightValue = BitConverter.ToInt16(hogFile.Data, offset);
                offset += 2;

                Cubes[Cubes.Count - 1].WallsMask = (WallsBitMask) hogFile.Data[offset++];
                for (var j = 0; j < 6; j++)
                {
                    Cubes[Cubes.Count - 1].Sides[j] = new Wall();
                    if (((int) Cubes[Cubes.Count - 1].WallsMask & (1 << j)) != 0)
                    {
                        Cubes[Cubes.Count - 1].Sides[j].Number = hogFile.Data[offset++];
                        if (Cubes[Cubes.Count - 1].Sides[j].Number == 255)
                        {
                            Cubes[Cubes.Count - 1].Sides[j].Number = -1;
                        }
                    }
                    else
                    {
                        Cubes[Cubes.Count - 1].Sides[j].Number = -1;
                    }
                }

                // read textures for each side
                for (var j = 0; j < 6; j++)
                {
                    if (Cubes[Cubes.Count - 1].Children[j] == -1 || Cubes[Cubes.Count - 1].Sides[j].Number != -1)
                    {
                        // primary texture
                        var primaryTexture = BitConverter.ToInt16(hogFile.Data, offset);
                        Cubes[Cubes.Count - 1].Sides[j].PrimaryTexture = primaryTexture & 0x7fff;
                        offset += 2;
                        if ((primaryTexture & 0x8000) != 0)
                        {
                            // read the secondary texture
                            Cubes[Cubes.Count - 1].Sides[j].SecondaryTexture = BitConverter.ToInt16(hogFile.Data, offset);
                            offset += 2;
                        }

                        for (var k = 0; k < 4; k++)
                        {
                            //TODO: need to convert fixed point to float
                            Cubes[Cubes.Count - 1].Sides[j].Uvls[k] = new UVL
                            {
                                U = BitConverter.ToInt16(hogFile.Data, offset),
                                V = BitConverter.ToInt16(hogFile.Data, offset+2),
                                L = BitConverter.ToInt16(hogFile.Data, offset+4)
                            };
                            offset += 6;
                        }
                    }
                }

                
            }
        }
    }
}
