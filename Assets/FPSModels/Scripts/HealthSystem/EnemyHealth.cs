using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    public float Health { get { return _health; } set { _health = value; } }
    private bool _isDead;
    private EnemyAudioContoller _audioContoller;

    public void ApplyDamage(float damage)
    {
        if (_isDead) 
            return; 

        _health -= damage;

        if(_health <= 0f)
        {
            _isDead = true;
            OnDead();
        }
    }

    private void OnDead()
    {
        StartCoroutine(PlayDeathSound());
    }

    private IEnumerator PlayDeathSound()
    {
        yield return new WaitForSeconds(0.3f);
        _audioContoller.PlayDyingSound();
    }
}
