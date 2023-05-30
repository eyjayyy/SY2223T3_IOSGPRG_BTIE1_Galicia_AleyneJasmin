using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool inRange;

    void Start()
    {
        inRange = false;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        inRange = true;
        Debug.Log("Enemy in Range!");
    }

}
