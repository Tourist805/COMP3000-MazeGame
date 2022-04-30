using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract void ApplyDamage(float damage);
    public abstract void OnDead();
}
