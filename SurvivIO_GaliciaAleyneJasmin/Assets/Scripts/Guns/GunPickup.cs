using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] private GameObject _gunObj;
    [SerializeField] private WeaponType _weaponType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Inventory _playerInventory = collision.gameObject.GetComponent<Inventory>();

            _playerInventory.PickupGun(_gunObj, _weaponType);
            
            Destroy(this.gameObject);
        }
    }
}
