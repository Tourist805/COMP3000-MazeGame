using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public IntVector2 coordinates;

    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];
    public MazeRoom Room;


    private int _initializedEdgeCount;

    public bool IsFullyInitialized
    {
        get
        {
            return _initializedEdgeCount == MazeDirections.Count;
        }
    }

    public void Initialize(MazeRoom room)
    {
        room.Add(this);
        transform.GetChild(0).GetComponent<Renderer>().material = room.settings.FloorMaterial;
    }

    public MazeCellEdge GetEdge(MazeDirection direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(MazeDirection direction, MazeCellEdge edge)
    {
        edges[(int)direction] = edge;
        _initializedEdgeCount += 1;
    }

    public MazeDirection RandomUninitializedDirection
    {
        get
        {
            int skips = Random.Range(0, MazeDirections.Count - _initializedEdgeCount);
            for (int i = 0; i < MazeDirections.Count; i++)
            {
                if (edges[i] == null)
                {
                    if (skips == 0)
                    {
                        return (MazeDirection)i;
                    }
                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }
}
