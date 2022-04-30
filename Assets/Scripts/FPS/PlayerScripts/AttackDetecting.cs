using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetecting : MonoBehaviour
{
    [SerializeField] private float _damage = 2f;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        ObserveHits();
    }

    private void ObserveHits()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius, _layerMask);

        if(hits.Length > 0)
        {
            //hits[0].gameObject.GetComponent<HealthHandler>().ApplyDamage(_damage);
            hits[0].gameObject.GetComponent<Health>().ApplyDamage(_damage);
            Debug.Log("Touched " + hits[0].gameObject.tag);
            gameObject.SetActive(false);
        }
    }
}
