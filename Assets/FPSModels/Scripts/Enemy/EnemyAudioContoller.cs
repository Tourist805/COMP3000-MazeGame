using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAudioContoller : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _screamClip, _dyingClip;
    [SerializeField] private AudioClip[] _attackClips;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayScreamSound()
    {
        _audioSource.clip = _screamClip;
        _audioSource.Play();
    }

    public void PlayAttackSound()
    {
        _audioSource.clip = _attackClips[Random.Range(0, _attackClips.Length)];
        _audioSource.Play();
    }

    public void PlayDyingSound()
    {
        _audioSource.clip = _dyingClip;
        _audioSource.Play();
    }
}
