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

    private void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
        //_zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
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
        if(_weaponManager.GetCurrentWeapon().WeaponFire == WeaponFireType.Multiple)
        {
            if(Input.GetMouseButton(0) && Time.time > _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / _fireRate;
                _weaponManager.GetCurrentWeapon().StartShootingAnimation();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(_weaponManager.GetCurrentWeapon().tag == Tags.AXE_TAG)
                {
                    _weaponManager.GetCurrentWeapon().StartShootingAnimation();
                }

                if(_weaponManager.GetCurrentWeapon().BulletType == WeaponBulletType.Bullet)
                {
                    _weaponManager.GetCurrentWeapon().StartShootingAnimation();
                    // shooting bullets
                }
                else
                {
                    // spear and arrow
                    if(_isAiming)
                    {
                        _weaponManager.GetCurrentWeapon().StartShootingAnimation();
                        if(_weaponManager.GetCurrentWeapon().BulletType == WeaponBulletType.Arrow)
                        {

                        }
                        else if(_weaponManager.GetCurrentWeapon().BulletType == WeaponBulletType.Spear)
                        {

                        }
                    }
                }
            }
        }
    }

    private void PerformZooming()
    {
        // Aiming camera to the weapon
        Debug.Log("Zooming: " + _weaponManager.GetCurrentWeapon().WeaponAim);
        if(_weaponManager.GetCurrentWeapon().WeaponAim == WeaponAim.Aim)
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

        if(_weaponManager.GetCurrentWeapon().WeaponAim == WeaponAim.SelfAim)
        {
            if(Input.GetMouseButtonDown(1))
            {
                _weaponManager.GetCurrentWeapon().Aim(true);
                _isAiming = true;
            }
            if(Input.GetMouseButtonUp(1))
            {
                _weaponManager.GetCurrentWeapon().Aim(true);
                _isAiming = false;
            }
        }
    }
}
