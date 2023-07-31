using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    private class _Ammo
    {
        public string _name;
        public AmmoType _ammoType;
        public int _capacity;
        public int _currentClip;
        public TMP_Text _ammoText;
    }

    [SerializeField] private List<_Ammo> ammos;
    // [SerializeField] private List<Gun> guns;

    [Header("Guns")]
    [SerializeField] private GameObject primaryGun;
    [SerializeField] private GameObject secondaryGun;

    void Start()
    {

    }

    public void AddAmmo(int amount, AmmoType ammoType)
    {
        foreach (_Ammo a in ammos)
        {
            if (a._ammoType == ammoType)
            {
                a._currentClip += amount;
                a._currentClip = Mathf.Min(a._currentClip, a._capacity);

                Debug.Log($"{a._name} current clip is {a._currentClip}");
                a._ammoText.text = a._currentClip.ToString();
                break;
            }
        }

        Debug.Log("Accessed");
    }

    public void PickupGun(GameObject gunPrefab, WeaponType weaponType)
    {   
        Vector3 gunOffset = transform.up * 0.8f;;
        Vector3 position = transform.position + gunOffset;
        GameObject gunGO = Instantiate(gunPrefab, position, transform.rotation);
        gunGO.transform.parent = transform;

        if (weaponType == WeaponType.Primary)
        {
            if (primaryGun != null)
            {
                Destroy(primaryGun);
            }

            if (secondaryGun != null && secondaryGun.activeInHierarchy)
            {
                secondaryGun.SetActive(false);
            }

            primaryGun = gunGO;
        }

        else
        {
            if (primaryGun != null && primaryGun.activeInHierarchy)
            {
                primaryGun.SetActive(false);
            }

            secondaryGun = gunGO;
        }

        // Gun _gun = gunPrefab.GetComponent<Gun>();

        // guns.Add(_gun);
    }
}
