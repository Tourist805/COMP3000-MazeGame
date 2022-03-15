using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _offset = 10f;
    private Transform _playerPosition;
    private bool _isOpened = false;

    private void Awake()
    {
        _playerPosition = (FindObjectOfType<PlayerMark>()).gameObject.transform;
    }
    private void Update()
    {
        if(!_isOpened)
        {
            if (Vector3.Distance(transform.position, _playerPosition.position) <= _radius)
            {
                Debug.Log("here");
                StartCoroutine(TurnUp());
                _isOpened = true;
            }
        } 
    }

    private IEnumerator TurnUp()
    {
        yield return new WaitForSeconds(4.0f);
        transform.Translate(new Vector3(0f, _offset, 0f) * Time.deltaTime); 
    }

    private void TurnDown()
    {
        transform.Translate(0f, 0f, 0f);
    }
}
