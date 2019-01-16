using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DescentHogFileReader;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Transform pointPrefab;
    Vector2[] newUV;

    /// <summary>
    /// Mesh used to generate cube
    /// </summary>
    private Mesh cubeMesh;


    // Start is called before the first frame update
    void Start()
    {
        ReadHogFile();
        //MakeCube();
    }

    private void ReadHogFile()
    {
        Rdl rdlFile;
        byte[] buffer = File.ReadAllBytes("Assets/DESCENT.HOG");
        char[] fileSignature = {(char) buffer[0], (char) buffer[1], (char) buffer[2]};

        int index = 3;

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

                    // plot cubes for each point
                    
                    // plot the polygon corners
                    foreach (var vertex in rdlFile.Vertices)
                    {
                        var point = Instantiate(pointPrefab);
                        point.localPosition = new Vector3 {x = (float)vertex.X, y = (float)vertex.Y, z = (float)vertex.Z};
                    }

                    var mesh = GetCubeMesh();
                    var totalVertices = new List<Vector3>();
                    foreach (var vertex in rdlFile.Vertices)
                    {
                        totalVertices.Add(new Vector3{ x = (float)vertex.X, y = (float)vertex.Y, z = (float)vertex.Z });
                    }

                    mesh.vertices = totalVertices.ToArray();

                    var triangles = new List<int>();
                    var uvs = new List<Vector2>();
                    foreach (var cube in rdlFile.Cubes)
                    {
                        AddTriangles(triangles, cube);
                        AddUvs(uvs);
                    }

                    mesh.triangles = triangles.ToArray();
                    mesh.uv = uvs.ToArray();

                    mesh.RecalculateNormals();
                    mesh.RecalculateBounds();

                    break;
                }
        }
    }

    private void AddTriangles(List<int> triangles, CubeRecord cube)
    {
        // left
        triangles.Add(cube.BoxVertices[2]);
        triangles.Add(cube.BoxVertices[6]);
        triangles.Add(cube.BoxVertices[7]);
        triangles.Add(cube.BoxVertices[7]);
        triangles.Add(cube.BoxVertices[3]);
        triangles.Add(cube.BoxVertices[2]);

        // top
        triangles.Add(cube.BoxVertices[0]);
        triangles.Add(cube.BoxVertices[3]);
        triangles.Add(cube.BoxVertices[7]);
        triangles.Add(cube.BoxVertices[7]);
        triangles.Add(cube.BoxVertices[4]);
        triangles.Add(cube.BoxVertices[0]);

        // right
        triangles.Add(cube.BoxVertices[1]);
        triangles.Add(cube.BoxVertices[0]);
        triangles.Add(cube.BoxVertices[4]);
        triangles.Add(cube.BoxVertices[4]);
        triangles.Add(cube.BoxVertices[5]);
        triangles.Add(cube.BoxVertices[1]);

        // bottom
        triangles.Add(cube.BoxVertices[1]);
        triangles.Add(cube.BoxVertices[5]);
        triangles.Add(cube.BoxVertices[6]);
        triangles.Add(cube.BoxVertices[6]);
        triangles.Add(cube.BoxVertices[2]);
        triangles.Add(cube.BoxVertices[1]);

        // back
        triangles.Add(cube.BoxVertices[7]);
        triangles.Add(cube.BoxVertices[6]);
        triangles.Add(cube.BoxVertices[5]);
        triangles.Add(cube.BoxVertices[5]);
        triangles.Add(cube.BoxVertices[4]);
        triangles.Add(cube.BoxVertices[7]);

        // front
        triangles.Add(cube.BoxVertices[0]);
        triangles.Add(cube.BoxVertices[1]);
        triangles.Add(cube.BoxVertices[2]);
        triangles.Add(cube.BoxVertices[2]);
        triangles.Add(cube.BoxVertices[3]);
        triangles.Add(cube.BoxVertices[0]);
    }

    private Mesh GetCubeMesh()
    {
        if (GetComponent<MeshFilter>() == null)
        {
            MeshFilter filter = gameObject.AddComponent<MeshFilter>();
            Mesh mesh = filter.mesh;
            mesh.Clear();
            return mesh;
        }
        else
        {
            return gameObject.GetComponent<MeshFilter>().mesh;
        }
    }

    private void AddUvs(List<Vector2> uvs)
    {
        for (var i = 0; i < 6; i++)
        {
            // same uvs for all faces
            uvs.Add(new Vector2(0, 0));
            uvs.Add(new Vector2(1, 0));
            uvs.Add(new Vector2(1, 1));
            uvs.Add(new Vector2(0, 1));
        }
    }
    private void DrawSide()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
