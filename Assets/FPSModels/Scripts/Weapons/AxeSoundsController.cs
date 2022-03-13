using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSoundsController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _whistleSounds;

    private void PlaySound()
    {
        _audioSource.clip = _whistleSounds[Random.Range(0, _whistleSounds.Length)];
        _audioSource.Play();
    }
}
