using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private MazeDoor _door;

    private void Awake()
    {
        _door = GetComponentInParent<MazeDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CharacterController characterController))
        {
            _door.OnPlayerEntered();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out CharacterController characterController))
        {
            _door.OnPlayerExited();
        }
    }
}
