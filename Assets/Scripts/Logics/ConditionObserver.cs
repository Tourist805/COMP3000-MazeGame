using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionObserver : MonoBehaviour
{
    [SerializeField] private GameOverUI _gameoverUI;

    private void OnEnable()
    {
        PlayerHealth.PlayerDead += _gameoverUI.Open;
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDead -= _gameoverUI.Open;
    }
}
