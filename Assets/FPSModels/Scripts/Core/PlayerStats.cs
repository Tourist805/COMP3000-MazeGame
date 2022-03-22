using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Image _healthBarStats;

    private void Awake()
    {
        HealthBarImage healthBar = FindObjectOfType<HealthBarImage>();
        _healthBarStats = healthBar.GetComponent<Image>();
    }

    public void DisplayHealthStats(float healthValue)
    {
        healthValue /= 100f;
        _healthBarStats.fillAmount = healthValue;
    }
}
