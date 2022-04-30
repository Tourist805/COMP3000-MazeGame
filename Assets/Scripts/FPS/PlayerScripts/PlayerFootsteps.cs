using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource _footstepSound;

    [SerializeField] private AudioClip[] _footstepClips;
    private CharacterController _characterController;
    private float _volumeMin, _volumeMax;
    private float _accumulatedDistance;
    private float _stepDistance;
    public float VolumeMin { get { return _volumeMin; } set { _volumeMin = value; } }
    public float VolumeMax { get { return _volumeMax; } set { _volumeMax = value; } }
    public float StepDistance { get { return _stepDistance; } set { _stepDistance = value; } }
    private void Awake()
    {
        _footstepSound = GetComponent<AudioSource>();
        _characterController = GetComponentInParent(typeof(CharacterController)) as CharacterController;
    }
    private void Update()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        if (!_characterController.isGrounded)
            return;

        if(_characterController.velocity.sqrMagnitude > 0)
        {
            _accumulatedDistance += Time.deltaTime;

            if(_accumulatedDistance > _stepDistance)
            {
                _footstepSound.volume = Random.Range(_volumeMin, _volumeMax);
                _footstepSound.clip = _footstepClips[Random.Range(0, _footstepClips.Length)];
                _footstepSound.Play();

                _accumulatedDistance = 0f;
            }
        }
        else
        {
            _accumulatedDistance = 0f;
        }
    }
}
