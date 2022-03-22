using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    private MazeCell _cell;

    private void Start()
    {
        _cell = GetComponentInParent<MazeCell>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Debug.Log("current cell " + _cell.name);
            player.SetNextLocation(_cell);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CharacterController characterController))
        {
            
        }
    }
}
