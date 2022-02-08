using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MazePassage
{
    public Transform Hinge;

    private MazeDoor _otherSideOfDoor
    {
        get
        {
            return otherCell.GetEdge(direction.GetOpposite()) as MazeDoor;
        }
    }

    public override void Initialize(MazeCell primary, MazeCell other, MazeDirection direction)
    {
        base.Initialize(primary, other, direction);
        if (_otherSideOfDoor != null)
        {
            Hinge.localScale = new Vector3(-1f, 1f, 1f);
            Vector3 p = Hinge.localPosition;
            p.x = -p.x;
            Hinge.localPosition = p;
        }
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Transform child = transform.GetChild(i);
        //    if(child != Hinge)
        //    {
        //        child.GetComponent<Renderer>().material = cell.Room.settings.WallMaterial;
        //    }
        //}
    }
}
