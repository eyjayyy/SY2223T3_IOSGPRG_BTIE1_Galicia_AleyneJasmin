using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    Pistol,
    AutomaticRifle,
    Shotgun
};

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType _ammoType;
    //[SerializeField] private Ammo _ammo;
    [SerializeField] private int _ammoToPickup;

    void Start()
    {
        RandomizeAmmoCount(_ammoType);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Inventory _playerInventory = collision.gameObject.GetComponent<Inventory>();

            _playerInventory.AddAmmo(_ammoToPickup, _ammoType);
            
            Destroy(this.gameObject);
        }
    }

    private void RandomizeAmmoCount(AmmoType ammoType)
    {
        switch(ammoType)
        {
            case AmmoType.Pistol:
                _ammoToPickup = Random.Range(1, 9);
            break;

            case AmmoType.AutomaticRifle:
                _ammoToPickup = Random.Range(5, 16);
            break;

            case AmmoType.Shotgun:
                _ammoToPickup = Random.Range(1, 3);
            break;
        }
    }
}
