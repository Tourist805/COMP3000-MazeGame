using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int Count = 0;

    public static void AddPoints(DamageType type)
    {
        switch (type)
        {
            case DamageType.Cyclope:
            {
                Count += 30;
                break; 
            }
            case DamageType.Boar:
            {
                Count += 50;
                break;
            }
            case DamageType.Fiery:
            {
                Count += 30;
                break;
            }
        }

    }
}
