using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthHandler : MonoBehaviour
{
    private EnemyAnimator _enemyAnimator;
    private NavMeshAgent _navMeshAgent;
    private EnemyController _enemyController;

    [SerializeField] private float _health = 100f;

    [SerializeField] private bool _isPlayer, _isBoar, _isCannibal;
    private bool _isDead;

    private void Awake()
    {
        if(_isBoar || _isCannibal)
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _enemyController = GetComponent<EnemyController>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        if(_isPlayer)
        {

        }
    }

    public void ApplyDamage(float damage)
    {
        if(_isDead)
        {
            return;
        }

        _health -= damage;

    }
}
