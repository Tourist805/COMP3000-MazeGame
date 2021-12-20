using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMeshGenerator
{
    public float Width;
    public float Height;

    public MazeMeshGenerator()
    {
        Width = 3.75f;
        Height = 3.5f;
    }

    public Mesh FromData(int[,] data)
    {
        Mesh maze = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();

        maze.subMeshCount = 2;

        List<int> floorTriangles = new List<int>();
        List<int> wallTriangles = new List<int>();

        int maximumRows = data.GetUpperBound(0);
        int maximumCols = data.GetUpperBound(1);
        float halfHeight = Height * .5f;

        for (int i = 0; i <= maximumRows; i++)
        {
            for (int j = 0; j <= maximumCols; j++)
            {
                if (data[i, j] != 1)
                {
                    // floor
                    addQuad(Matrix4x4.TRS(
                        new Vector3(j * Width, 0, i * Width),
                        Quaternion.LookRotation(Vector3.up),
                        new Vector3(Width, Width, 1)
                    ), ref vertices, ref uvs, ref floorTriangles);

                    // ceiling
                    addQuad(Matrix4x4.TRS(
                        new Vector3(j * Width, Height, i * Width),
                        Quaternion.LookRotation(Vector3.down),
                        new Vector3(Width, Width, 1)
                    ), ref vertices, ref uvs, ref floorTriangles);


                    // walls

                    if (i - 1 < 0 || data[i - 1, j] == 1)
                    {
                        addQuad(Matrix4x4.TRS(
                            new Vector3(j * Width, halfHeight, (i - .5f) * Width),
                            Quaternion.LookRotation(Vector3.forward),
                            new Vector3(Width, Height, 1)
                        ), ref vertices, ref uvs, ref wallTriangles);
                    }

                    if (j + 1 > maximumCols || data[i, j + 1] == 1)
                    {
                        addQuad(Matrix4x4.TRS(
                            new Vector3((j + .5f) * Width, halfHeight, i * Width),
                            Quaternion.LookRotation(Vector3.left),
                            new Vector3(Width, Height, 1)
                        ), ref vertices, ref uvs, ref wallTriangles);
                    }

                    if (j - 1 < 0 || data[i, j - 1] == 1)
                    {
                        addQuad(Matrix4x4.TRS(
                            new Vector3((j - .5f) * Width, halfHeight, i * Width),
                            Quaternion.LookRotation(Vector3.right),
                            new Vector3(Width, Height, 1)
                        ), ref vertices, ref uvs, ref wallTriangles);
                    }

                    if (i + 1 > maximumRows || data[i + 1, j] == 1)
                    {
                        addQuad(Matrix4x4.TRS(
                            new Vector3(j * Width, halfHeight, (i + .5f) * Width),
                            Quaternion.LookRotation(Vector3.back),
                            new Vector3(Width, Height, 1)
                        ), ref vertices, ref uvs, ref wallTriangles);
                    }
                }
            }
        }

        maze.vertices = vertices.ToArray();
        maze.uv = uvs.ToArray();

        maze.SetTriangles(floorTriangles.ToArray(), 0);
        maze.SetTriangles(wallTriangles.ToArray(), 1);

        maze.RecalculateNormals();

        return maze;
    }

    private void addQuad(Matrix4x4 matrix, ref List<Vector3> vertices,
        ref List<Vector2> uvs, ref List<int> triangles)
    {
        int index = vertices.Count;

        Vector3 vertex1 = new Vector3(-.5f, -.5f, 0);
        Vector3 vertex2 = new Vector3(-.5f, .5f, 0);
        Vector3 vertex3 = new Vector3(.5f, .5f, 0);
        Vector3 vertex4 = new Vector3(.5f, -.5f, 0);

        vertices.Add(matrix.MultiplyPoint3x4(vertex1));
        vertices.Add(matrix.MultiplyPoint3x4(vertex2));
        vertices.Add(matrix.MultiplyPoint3x4(vertex3));
        vertices.Add(matrix.MultiplyPoint3x4(vertex4));

        uvs.Add(new Vector2(1, 0));
        uvs.Add(new Vector2(1, 1));
        uvs.Add(new Vector2(0, 1));
        uvs.Add(new Vector2(0, 0));

        triangles.Add(index + 2);
        triangles.Add(index + 1);
        triangles.Add(index);

        triangles.Add(index + 3);
        triangles.Add(index + 2);
        triangles.Add(index);
    }
}
