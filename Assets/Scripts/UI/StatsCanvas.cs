using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCanvas : MonoBehaviour
{
    public void ActivateStats()
    {
        Debug.Log("Activate Stats");
        gameObject.SetActive(true);
    }

    public void HideStats()
    {
        gameObject.SetActive(false);
    }
}
