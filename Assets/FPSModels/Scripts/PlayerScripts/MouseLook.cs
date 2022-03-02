using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerRoot, _lookRoot;
    [SerializeField] private bool _invert;
    [SerializeField] private bool _canUnlock = true;

    [SerializeField] private float _sensetivity = 5f;
    [SerializeField] private int _smoothSteps = 10;

    [SerializeField] private float _smoothWeight = 4.0f;

    [SerializeField] private float _rollAngle = 10f;
    [SerializeField] private float _rollSpeed = 3f;
    [SerializeField] private Vector2 _defaultLookLimits = new Vector2(-70f, 80f);

    private Vector2 _lookAngles, _currentMouseLook;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LockAndUnlockCursor();

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

    private void LockAndUnlockCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void LookAround()
    {
        _currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSEY), Input.GetAxis(MouseAxis.MOUSEX));

        _lookAngles.x += _currentMouseLook.x * _sensetivity * (_invert ? 1f : -1f);
        _lookAngles.y += _currentMouseLook.y * _sensetivity;

        _lookAngles.x = Mathf.Clamp(_lookAngles.x, _defaultLookLimits.x, _defaultLookLimits.y);

        _lookRoot.localRotation = Quaternion.Euler(_lookAngles.x, 0f, 0f);
        _playerRoot.localRotation = Quaternion.Euler(0f, _lookAngles.y, 0f);
    }
}
