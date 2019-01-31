using System;
using System.Collections.Generic;
using System.IO;

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

            var ver = hogFile.Data[MineDataOffset]; // one byte for version
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
                Cubes.Add(new CubeRecord(hogFile.Data, offset));
                offset += Cubes[Cubes.Count-1].Length;
            }

            /*
            File.Delete(@"c:\temp\DescentAssets\cube_texture_list.txt");

            for (var i = 0; i < cubeCount; i++)
            {
                File.AppendAllText(@"c:\temp\DescentAssets\cube_texture_list.txt", Environment.NewLine + "Cube:" + i + Environment.NewLine);
                for (var j = 0; j < 6; j++)
                {
                    File.AppendAllText(@"c:\temp\DescentAssets\cube_texture_list.txt", Cubes[i].Sides[j].WallName+":" + Cubes[i].Sides[j].PrimaryTexture + Environment.NewLine);
                }
            }
            */
        }
    }
}
