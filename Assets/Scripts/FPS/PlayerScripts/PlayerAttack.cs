using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
public class PlayerAttack : MonoBehaviour
{
    private WeaponManager _weaponManager;
    [SerializeField] private float _fireRate = 15f;
    private float _nextTimeToFire;
    [SerializeField] private float _damage = 20f;

    private Animator _zoomCameraAnim;
    private bool _isZoomed;
    [SerializeField] private Camera _camera;
    private bool _isAiming;
    private GameObject _crossHair;
    private WeaponHandler _weapon => _weaponManager.GetCurrentWeapon();

    [SerializeField] private GameObject _arrowPrefab, _spearPrefab;
    [SerializeField] private Transform _projectileStartPosition;

    private void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
        _zoomCameraAnim = (FindObjectOfType<FPCamera>()).gameObject.GetComponent<Animator>();
        _crossHair = (FindObjectOfType<CrossHair>()).gameObject;
    }

    private void Update()
    {
        WeaponShoot();
        PerformZooming();
    }

    private void WeaponShoot()
    {
        if(_weapon.WeaponFire == WeaponFireType.Multiple)
        {
            if(Input.GetMouseButton(0) && Time.time > _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / _fireRate;
                _weapon.StartShootingAnimation();
                FireBullet();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(_weapon.tag == Tags.AXE_TAG)
                {
                    _weapon.StartShootingAnimation();
                }

                if(_weapon.BulletType == WeaponBulletType.Bullet)
                {
                    _weapon.StartShootingAnimation();
                    FireBullet();
                }
                else
                {
                    // spear and arrow
                    if(_isAiming)
                    {
                        _weapon.StartShootingAnimation();
                        if(_weapon.BulletType == WeaponBulletType.Arrow)
                        {
                            ThrowProjectile(true);
                        }
                        else if(_weapon.BulletType == WeaponBulletType.Spear)
                        {
                            ThrowProjectile(false);
                        }
                    }
                }
            }
        }
    }

    private void PerformZooming()
    {
        // Aiming camera to the weapon
        if(_weapon.WeaponAim == WeaponAim.Aim)
        {
            if(Input.GetMouseButtonDown(1))
            {
                _zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                _crossHair.SetActive(false);
            }
            if(Input.GetMouseButtonUp(1))
            {
                _zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                _crossHair.SetActive(true);
            }
        }

        if(_weapon.WeaponAim == WeaponAim.SelfAim)
        {
            if(Input.GetMouseButtonDown(1))
            {
                _weapon.Aim(true);
                _isAiming = true;
            }
            if(Input.GetMouseButtonUp(1))
            {
                _weapon.Aim(false);
                _isAiming = false;
            }
        }
    }

    private void ThrowProjectile(bool throwArrow)
    {
        if(throwArrow)
        {
            GameObject arrow = Instantiate(_arrowPrefab);
            arrow.transform.position = _projectileStartPosition.position;
            arrow.GetComponent<ProjectileSpawn>().Launch(_camera);
        }
        else
        {
            GameObject spear = Instantiate(_spearPrefab);
            spear.transform.position = _projectileStartPosition.position;
            spear.GetComponent<ProjectileSpawn>().Launch(_camera);
        }
    }

    private void FireBullet()
    {
        RaycastHit hit;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit))
        {
            if(hit.transform.tag == Tags.ENEMY_TAG)
            {
                Debug.Log(hit.transform.tag);
                hit.transform.GetComponent<EnemyHealth>().ApplyDamage(_damage);
            }
        }
    }
}
