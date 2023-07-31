using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Ammo: MonoBehaviour
{
    public string _name;
    public AmmoType _ammoType;
    public int _capacity;
    public int _currentClip;
    public TMP_Text _ammoText;
    
    void Start()
    {
        //_ammoText = gameObject.GetComponent<TMP_Text>();
    }

    public void AddAmmo(int amount)
    {
        _currentClip += amount;
        _currentClip = Mathf.Min(_currentClip, _capacity);

        Debug.Log($"{_ammoType} current clip is {_currentClip}");
        _ammoText.text = _currentClip.ToString();
    }
}
