using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCanvas : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _scoreText;
    public void ActivateStats()
    {
        Debug.Log("Activate Stats");
        gameObject.SetActive(true);
    }

    public void HideStats()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _scoreText.text = "Score: " + Coin.Count.ToString();
    }
}
