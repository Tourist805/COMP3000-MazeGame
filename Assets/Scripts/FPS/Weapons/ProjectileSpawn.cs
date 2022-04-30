using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileSpawn : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _deactivateTimer = 3f;
    [SerializeField] private float _damage = 15f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Invoke("Deactivate", _deactivateTimer);
    }

    private void Deactivate()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == Tags.ENEMY_TAG)
        {
            target.GetComponent<HealthHandler>().ApplyDamage(_damage);

            gameObject.SetActive(false);
        }
    }

    public void Launch(Camera camera)
    {
        _rigidbody.velocity = camera.transform.forward * _speed;
        transform.LookAt(transform.position + _rigidbody.velocity);
    }
}
