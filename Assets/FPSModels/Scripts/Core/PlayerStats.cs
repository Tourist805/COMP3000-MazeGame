using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Image _healthBarStats;

    public void DisplayHealthStats(float healthValue)
    {
        healthValue /= 100f;
        _healthBarStats.fillAmount = healthValue;
    }
}
