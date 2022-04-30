using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAnimator), typeof(EnemyController), typeof(NavMeshAgent))]
public class EnemyHealth : Health
{
    [SerializeField] private float _health = 100f;
    public float Health { get { return _health; } set { _health = value; } }
    private bool _isDead;
    [SerializeField] private float _chasingRadius = 50f;
    private EnemyAudioContoller _audioController;
    private EnemyAnimator _enemyAnimator;
    private NavMeshAgent _navMeshAgent;
    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _enemyController = GetComponent<EnemyController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _audioController = GetComponentInChildren<EnemyAudioContoller>();
    }

    public override void ApplyDamage(float damage)
    {
        if (_isDead) 
            return; 

        _health -= damage;

        if (_enemyController.EnemyState == EnemyState.Patrol)
        {
            _enemyController.ChaseDistance = _chasingRadius;
        }

        if (_health <= 0f)
        {
            _isDead = true;
            OnDead();
        }
    }

    public override void OnDead()
    {
        _navMeshAgent.velocity = Vector3.zero;
        _navMeshAgent.isStopped = true;
        _enemyController.enabled = false;

        _enemyAnimator.PerformDying();
        StartCoroutine(PlayDeathSound());
        if (gameObject.tag == "Enemy")
        {
            Coin.AddPoints(DamageType.Cyclope);
        }

        Invoke("TurnOffGameObject", 3f);
        
        
    }

    private void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator PlayDeathSound()
    {
        yield return new WaitForSeconds(0.3f);
        _audioController.PlayDyingSound();
    }
}
