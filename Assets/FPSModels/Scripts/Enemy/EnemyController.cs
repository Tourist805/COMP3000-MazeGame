using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private EnemyAnimator _enemyAnimator;
    private NavMeshAgent _navAgent;

    private EnemyState _enemyState;

    [SerializeField] private float _walkSpeed = 0.5f;
    [SerializeField] private float _runSpeed = 4f;

    [SerializeField] private float _chaseDistance = 7f;
    private float _currentChaseDistance;
    [SerializeField] private float _attackDistance = 1.8f;
    [SerializeField] private float _chaseAffterAttackDistance = 2f;
    [SerializeField] private float _patrolRadiusMinimum = 20f, _patrolRadiusMax = 60f;
    [SerializeField] private float _patrolThisTime = 15f;
    private float _patrolTimer;

    [SerializeField] private float _waitBeforeAttack = 2f;
    private float _attackTimer;

    private Transform target;


    private void Awake()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _navAgent = GetComponent<NavMeshAgent>();

        target = (FindObjectOfType<PlayerMark>()).gameObject.transform;
    }

    private void Start()
    {
        _enemyState = EnemyState.Patrol;

        _patrolTimer = _patrolThisTime;

        _attackTimer = _waitBeforeAttack;

        _currentChaseDistance = _chaseDistance;
    }

    private void Update()
    {
        switch(_enemyState)
        {
            case EnemyState.Patrol: 
                Patrol(); 
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    private void Patrol()
    {
        _navAgent.isStopped = false;
        _navAgent.speed = _walkSpeed;

        _patrolTimer += Time.deltaTime;

        if(_patrolTimer > _patrolThisTime)
        {
            SetRandomDestination();
            _patrolTimer = 0f;
        }

        if(_navAgent.velocity.sqrMagnitude > 0)
        {
            _enemyAnimator.PerformWalk(true);
        }
        else
        {
            _enemyAnimator.PerformWalk(false);
        }

        if(Vector3.Distance(transform.position, target.position) <= _chaseDistance)
        {
            _enemyAnimator.PerformWalk(false);
            _enemyState = EnemyState.Chase;
        }
    }

    private void Chase()
    {
        _navAgent.isStopped = false;
        _navAgent.speed = _runSpeed;

        _navAgent.SetDestination(target.position);

        if(_navAgent.velocity.sqrMagnitude > 0)
        {
            _enemyAnimator.PerformRun(true);
        }
        else
        {
            _enemyAnimator.PerformRun(false);
        }

        if(Vector3.Distance(transform.position, target.position) <= _attackDistance)
        {
            _enemyAnimator.PerformRun(false);
            _enemyAnimator.PerformWalk(false);
            _enemyState = EnemyState.Attack;

            if(_chaseDistance != _currentChaseDistance)
            {
                _chaseDistance = _currentChaseDistance;
            }
        }
        else if(Vector3.Distance(transform.position, target.position) > _chaseDistance)
        {
            _enemyAnimator.PerformRun(false);
            _enemyState = EnemyState.Patrol;
            _patrolTimer = _patrolThisTime;

            if (_chaseDistance != _currentChaseDistance)
            {
                _chaseDistance = _currentChaseDistance;
            }
        }
    }

    private void Attack()
    {
        _navAgent.velocity = Vector3.zero;
        _navAgent.isStopped = true;

        _attackTimer += Time.deltaTime;

        if(_attackTimer > _waitBeforeAttack)
        {
            _enemyAnimator.PerformAttack();
            _attackTimer = 0f;

        }

        if(Vector3.Distance(transform.position, target.position) > (_attackDistance + _chaseAffterAttackDistance))
        {
            _enemyState = EnemyState.Chase;
        }
    }

    private void SetRandomDestination()
    {
        float randomRadius = Random.Range(_patrolRadiusMinimum, _patrolRadiusMax);

        Vector3 randomDirection = Random.insideUnitSphere * randomRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, -1);

        _navAgent.SetDestination(navHit.position);
    }
}
