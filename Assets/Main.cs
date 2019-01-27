using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DescentHogFileReader;
using UnityEngine;

public class Main : MonoBehaviour
{
    private List<string> _textureNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        ReadHogFile();
    }

    private void ReadHogFile()
    {
        Rdl rdlFile;
        byte[] buffer = File.ReadAllBytes("Assets/DESCENT.HOG");

        int index = 3;

        ReadTextureNames();

        var fileData = new List<HogFile>();

        while (index < buffer.Length)
        {
            fileData.Add(new HogFile(buffer, index));
            index += fileData[fileData.Count - 1].FileSize + 13 + 4;

            if (fileData[fileData.Count - 1].FileName == "level01.rdl")
                if (fileData[fileData.Count - 1].FileType == HogFileType.RDL)
                {
                    // read one rdl file and break out of the loop
                    rdlFile = new Rdl(fileData[fileData.Count - 1]);

                    //TODO: temporary UVs
                    Vector2[] uvs0 =
                    {
                        new Vector2(0, 0),
                        new Vector2(1, 0),
                        new Vector2(1, 1),
                        new Vector2(0, 1),
                    };

                    var sideList = new int [6, 4] {{2, 6, 7, 3}, {0, 3, 7, 4}, {1, 0, 4, 5}, {1, 5, 6, 2}, {7, 6, 5, 4}, {0, 1, 2, 3}};

                    foreach (var cube in rdlFile.Cubes)
                    {
                        for (var i = 0; i < 6; i++)
                        {
                            if (cube.Children[i] == -1 || cube.Sides[i].Number != -1)
                            {
                                // left side
                                var vertices = new Vector3[]
                                {
                                    new Vector3((float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 0]]].X, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 0]]].Y, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 0]]].Z),
                                    new Vector3((float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 1]]].X, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 1]]].Y, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 1]]].Z),
                                    new Vector3((float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 2]]].X, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 2]]].Y, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 2]]].Z),
                                    new Vector3((float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 3]]].X, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 3]]].Y, (float) rdlFile.Vertices[cube.BoxVertices[sideList[i, 3]]].Z),
                                };

                                AddWall(_textureNames[cube.Sides[i].PrimaryTexture], vertices, uvs0);
                            }
                        }
                    }

                    break;
                }
        }
    }

    private void ReadTextureNames()
    {
        // read the texture names (these were dumped from the PIG file)
        var textureNameList = Regex.Split(File.ReadAllText(@"Assets/texture_names.txt"), "\r\n");
        for (var i = 0; i < textureNameList.Length; i++)
        {
            _textureNames.Add(textureNameList[i]);
        }
    }

    private void AddWall(string textureName, Vector3[] vertices, Vector2[] uvs)
    {
        int[] triangles =
        {
            0, 1, 2, // left
            2, 3, 0,
        };

        var o = new GameObject();
        Instantiate(o);

        var mesh = new Mesh();
        var meshFilter =
            (UnityEngine.MeshFilter)
            o.AddComponent(typeof(MeshFilter));
        meshFilter.mesh = mesh;

        // mesh renderer
        var meshRenderer =
            (UnityEngine.MeshRenderer)
            o.AddComponent(typeof(MeshRenderer));

        var material = new Material(Shader.Find("Diffuse"));
        meshRenderer.materials = new Material[1];
        meshRenderer.materials[0] = material;

        //Load a Texture (Assets/Resources/Textures/texture01.png)
        var texture = Resources.Load<Texture2D>($"Textures/{textureName}");
        material.mainTexture = texture;

        meshRenderer.material = material;

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}
