using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWall : MazeCellEdge
{
    public Transform Wall;

    public override void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        base.Initialize(cell, otherCell, direction);
        Wall.GetComponent<Renderer>().material = cell.Room.settings.WallMaterial;
    }
}
