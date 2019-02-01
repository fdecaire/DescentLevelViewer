using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets;

//http://www.descent2.com/ddn/specs/rdl/
namespace DescentHogFileReader
{
    public class Rdl
    {
        public string LevelName { get; set; }
        public string Signature { get; set; }
        public int Version { get; set; }
        public int MineDataOffset { get; set; }
        public int ObjectsOffset { get; set; }
        public int FileSize { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<CubeRecord> Cubes { get; set; }

        public Rdl(HogFile hogFile, string levelName)
        {
            LevelName = levelName;

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
            var path = $@"c:\temp\DescentAssets\cube_texture_list_level_{LevelName}.txt";
            File.Delete(path);

            // dump the distinct texture list with a cube number and it's side
            var sideList = new Dictionary<int, string>();
            var translationTable = new TextureTranslation();

            for (var i = 0; i < cubeCount; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    if (Cubes[i].Sides[j].PrimaryTexture > -1)
                    {
                        var result = "Cube:" + i + " Wall:" + Cubes[i].Sides[j].WallName + " Texture:" + Cubes[i].Sides[j].PrimaryTexture + Environment.NewLine;

                        if (!sideList.ContainsKey(Cubes[i].Sides[j].PrimaryTexture) && translationTable[Cubes[i].Sides[j].PrimaryTexture] == 255)
                        {
                            sideList[Cubes[i].Sides[j].PrimaryTexture] = result;
                        }
                    }
                }
            }

            foreach (var side in sideList.OrderBy(x => x.Key))
            {
                File.AppendAllText(path, side.Value);
            }
            */
        }
    }
}
