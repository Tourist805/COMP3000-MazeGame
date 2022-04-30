using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    [SerializeField] private float _spintSpeed = 10f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _crouchSpeed = 2f;

    private Transform _lookRoot;
    [SerializeField] private float _standHeight = 0.3f, _crouchHeight = 0.01f;

    private bool _isCrouching;
    private PlayerFootsteps _playerFootsteps;
    private float _sprintVolume = 1f;
    private float _crouchVolume = 0.1f;
    private float _walkVolumeMin = 0.2f, _walkVolumeMax = 0.6f;

    private float _walkStepDistance = 0.4f;
    private float _sprintStepDistance = 0.25f;
    private float _crouchStepDistance = 0.5f;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _lookRoot = transform.GetChild(0);
        _playerFootsteps = GetComponentInChildren(typeof(PlayerFootsteps)) as PlayerFootsteps;
    }

    private void Start()
    {
        setVolumeAndDistance(_walkStepDistance, _walkVolumeMin, _walkVolumeMax);
    }

    private void Update()
    {
        Sprint();
        Crouch();
    }

    private void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !_isCrouching)
        {
            _playerMovement.Speed = _spintSpeed;
            setVolumeAndDistance(_sprintStepDistance, _sprintVolume, _sprintVolume);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !_isCrouching)
        {
            _playerMovement.Speed = _moveSpeed;
            setVolumeAndDistance(_walkStepDistance, _walkVolumeMin, _walkVolumeMax);
        }
        if(Input.GetKey(KeyCode.LeftShift) && !_isCrouching)
        {

        }
    }

    private void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(_isCrouching)
            {
                _lookRoot.localPosition = new Vector3(0f, _standHeight, 0f);
                _playerMovement.Speed = _moveSpeed;

                setVolumeAndDistance(_walkStepDistance, _walkVolumeMin, _walkVolumeMax);

                _isCrouching = false;
            }
            else
            {
                _lookRoot.localPosition = new Vector3(0f, _crouchHeight, 0f);
                _playerMovement.Speed = _crouchSpeed;

                setVolumeAndDistance(_crouchStepDistance, _crouchVolume, _crouchVolume);

                _isCrouching = true;
            }
        }
    }

    private void setVolumeAndDistance(float stepDistance, float volumeMin, float volumeMax)
    {
        _playerFootsteps.StepDistance = stepDistance;
        _playerFootsteps.VolumeMin = volumeMin;
        _playerFootsteps.VolumeMax = volumeMax;
    }
}
