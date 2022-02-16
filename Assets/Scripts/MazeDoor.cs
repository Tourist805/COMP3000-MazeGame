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

    private static Quaternion
        _normalRotation = Quaternion.Euler(0f, -90f, 0f),
        _mirroredRotation = Quaternion.Euler(0f, 90f, 0f);

    private bool _isMirrored;

    public override void Initialize(MazeCell primary, MazeCell other, MazeDirection direction)
    {
        base.Initialize(primary, other, direction);
        if (_otherSideOfDoor != null)
        {
            _isMirrored = true;
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

    public override void OnPlayerEntered()
    {
        _otherSideOfDoor.Hinge.localRotation = Hinge.localRotation = _isMirrored ? _mirroredRotation : _normalRotation;
        _otherSideOfDoor.cell.Room.Show();
    }

    public override void OnPlayerExited()
    {
        _otherSideOfDoor.Hinge.localRotation = Hinge.localRotation = Quaternion.identity;
        _otherSideOfDoor.cell.Room.Hide();
    }
}
