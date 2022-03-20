using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealth : Health
{
    private PlayerStats _playerStats;
    private bool _isDead;
    [SerializeField] private float _health = 100f;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    public override void ApplyDamage(float damage)
    {
        _health -= damage;
        _playerStats.DisplayHealthStats(_health);

        if (_health <= 0f)
        {
            OnDead();
            _isDead = true;
        }
    }

    public override void OnDead()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().enabled = false;
        }

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
    }
}
