using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Image _healthBarStats;

    private void Start()
    {
        GameObject healthBar = GameObject.FindWithTag(Tags.HEALTH_BAR_STATS);
        _healthBarStats = healthBar.GetComponent<Image>();
        if (_healthBarStats == null)
        {
            Debug.Log("Health bar stats");
        }
        
    }

    public void DisplayHealthStats(float healthValue)
    {
        healthValue /= 100f;
        _healthBarStats.fillAmount = healthValue;
    }
}
