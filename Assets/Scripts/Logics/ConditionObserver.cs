using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionObserver : MonoBehaviour
{
    [SerializeField] private GameOverUI _gameoverUI;
    [SerializeField] private int _winingCondition = 40;
    public static bool GameHasEnded = false;
    public int WiningCondition
    {
        get
        {
            return _winingCondition;
        }
        set
        {
            _winingCondition = value;
        }
    }

    private void Update()
    {
        if(Coin.Count >= _winingCondition)
        {
            GameHasEnded = true;
            _gameoverUI.SetCondition(true);
            _gameoverUI.Open();
            FreezePlayer();
        }
    }
    private void OnEnable()
    {
        PlayerHealth.PlayerDead += _gameoverUI.Open;
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDead -= _gameoverUI.Open;
    }

    private void FreezePlayer()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().enabled = false;
        }

        GameObject player = FindObjectOfType<Player>().gameObject;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerAttack>().enabled = false;
    }
}
