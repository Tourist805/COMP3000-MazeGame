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
    [SerializeField] private float _chasingRadius = 50f;
    private bool _isDead;
    private EnemyAudioContoller _audioController;
    private PlayerStats _playerStats;

    private void Awake()
    {
        if(_isBoar || _isCannibal)
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _enemyController = GetComponent<EnemyController>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _audioController = GetComponentInChildren<EnemyAudioContoller>();
        }

        if(_isPlayer)
        {
            _playerStats = GetComponent<PlayerStats>();
        }
    }

    public void ApplyDamage(float damage)
    {
        if(_isDead)
        {
            return;
        }

        _health -= damage;

        if(_isPlayer)
        {
            _playerStats.DisplayHealthStats(_health);
        }

        if(_isBoar || _isCannibal)
        {
            if(_enemyController.EnemyState == EnemyState.Patrol)
            {
                _enemyController.ChaseDistance = _chasingRadius;
            }
        }

        if(_health <= 0f)
        {
            OnDead();
            _isDead = true;
        }
    }

    private void OnDead()
    {
        if(_isCannibal)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 5f);

            _enemyController.enabled = false;
            _navMeshAgent.enabled = false;
            _enemyAnimator.enabled = false;

            StartCoroutine(PlayDeathSound());
        }

        if(_isBoar)
        {
            _navMeshAgent.velocity = Vector3.zero;
            _navMeshAgent.isStopped = true;
            _enemyController.enabled = false;

            _enemyAnimator.PerformDying();
            StartCoroutine(PlayDeathSound());
        }

        if(_isPlayer)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
        }

        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartSceneTest", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }

    private void RestartScene()
    {
        Debug.Log("You are dead");
        //UnityEngine.SceneManagement.SceneManager.LoadScene("DoorTest");
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
