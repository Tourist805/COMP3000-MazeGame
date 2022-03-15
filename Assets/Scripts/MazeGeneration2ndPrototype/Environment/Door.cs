using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen = false;
    public bool IsOpen => _isOpen;

    public void Open(Vector3 playerTransform)
    {
       Debug.Log("Open the door: ");
    }

    public void Close()
    {
        Debug.Log("Close the door: ");
    }
}
