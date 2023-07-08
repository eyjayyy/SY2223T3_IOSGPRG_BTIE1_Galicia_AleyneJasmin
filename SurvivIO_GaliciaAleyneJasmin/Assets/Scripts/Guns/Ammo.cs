using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public string _name;
    [SerializeField] AmmoType _ammoType;
    [SerializeField] private int _capacity;
    [SerializeField] private int _currentClip;
    [SerializeField] private TMP_Text _ammoText;
    
    void Start()
    {
        _ammoText = gameObject.GetComponent<TMP_Text>();
    }

    public void AddAmmo(int amount)
    {
        _currentClip += amount;
        _currentClip = Mathf.Min(_currentClip, _capacity);

        Debug.Log($"{_ammoType} current clip is {_currentClip}");
        _ammoText.text = _currentClip.ToString();
    }
}
