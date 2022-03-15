using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CharacterController characterController))
        {
            if(!_door.IsOpen)
            {
                _door.Open(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out CharacterController characterController))
        {
            if(_door.IsOpen)
            {
                _door.Close();
            }
        }
    }
}
