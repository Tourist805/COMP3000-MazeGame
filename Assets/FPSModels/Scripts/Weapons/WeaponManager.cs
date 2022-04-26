using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponHandler[] _weapons;

    private int _currentWeaponIndex;

    public WeaponHandler GetCurrentWeapon() => _weapons[_currentWeaponIndex];

    private void Start()
    {
        _currentWeaponIndex = 0;
        _weapons[_currentWeaponIndex].gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TurnOnSelectedWeapon(3);
        }

        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    TurnOnSelectedWeapon(4);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    TurnOnSelectedWeapon(5);
        //}
    }

    private void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (_currentWeaponIndex == weaponIndex)
            return;

        _weapons[_currentWeaponIndex].gameObject.SetActive(false);
        _weapons[weaponIndex].gameObject.SetActive(true);
        _currentWeaponIndex = weaponIndex;
    }
}
