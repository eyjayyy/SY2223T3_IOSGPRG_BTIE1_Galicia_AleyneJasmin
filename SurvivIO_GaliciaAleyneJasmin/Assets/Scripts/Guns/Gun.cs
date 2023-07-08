using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    Pistol,
    AutomaticRifle,
    Shotgun
};

public enum WeaponType
{
    Primary,
    Secondary
};

public class Gun : MonoBehaviour
{
    [SerializeField] private GunType _gunType;
    [SerializeField] private WeaponType _weaponType;

    [SerializeField] private int _maxCarry;
    [SerializeField] private int _clipCapacity;

    [SerializeField] private float _fireRate;
    [SerializeField] private float _spreadAmount;

    private int _currentClip;

    public virtual void Shoot()
    {
        Debug.Log("Base gun is shooting");
    }

    public void Reload()
    {
        Debug.Log("Base gun is reloading");
    }
}
