using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> _ammoCount;

    void Start()
    {
        _ammoCount = new List<GameObject>();
    }
}
