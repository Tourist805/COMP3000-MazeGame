using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponHandler : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private WeaponAim _weaponAim;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private AudioSource _shootSound, _reloadSound;

    [SerializeField] private WeaponFireType _weaponFire;
    [SerializeField] private WeaponBulletType _weaponBullet;
    [SerializeField] private GameObject _attackPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartShootAnimation()
    {
        _animator.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim)
    {
        _animator.SetBool(AnimationTags.AIM_PARAMETRE, canAim);
    }

    public void TurnOnMuzzleFlash()
    {
        _muzzleFlash.SetActive(true);
    }

    public void TurnOffMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
    }

    public void PlayShootSound()
    {
        _shootSound.Play();
    }

    public void PlayReloadSound()
    {
        _reloadSound.Play();
    }

    public void TurnOnAttackPoint()
    {
        _attackPoint.SetActive(true);
    }

    public void TurnOffAttackPoint()
    {
        if(_attackPoint.activeInHierarchy)
        {
            _attackPoint.SetActive(false);
        }
    }
}
