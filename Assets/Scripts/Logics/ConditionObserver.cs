using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionObserver : MonoBehaviour
{
    [SerializeField] private GameOverUI _gameoverUI;
    [SerializeField] private int _winingCondition = 40;
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
            _gameoverUI.SetCondition(true);
            _gameoverUI.Open();
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
}
