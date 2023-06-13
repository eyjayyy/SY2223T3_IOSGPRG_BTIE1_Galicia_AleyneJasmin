using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Enemy enemy;
    public bool inRange;

    void Start()
    {
        inRange = false;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponent<Enemy>().isAttacking = true;
            inRange = true;
            Debug.Log("Enemy in Range!");
        }
    }
}
