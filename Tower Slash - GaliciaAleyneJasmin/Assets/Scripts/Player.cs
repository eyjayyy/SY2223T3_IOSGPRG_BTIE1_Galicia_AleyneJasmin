using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Enemy enemy;
    public bool inRange;
    public bool isDead;
    public int hp = 3;
    public int currentHp;
    public float movementSpeed; 
    public int dashPercent;
    public bool isInvulnerable;
    public TMP_Text hpText;
    public GameObject gameOverText;

    void Start()
    {
        inRange = false;
        currentHp = hp;
        DisplayPlayerHP();
    }

    void Update()
    {
        if (!isInvulnerable && !isDead)
        {
            transform.position += Vector3.up * Time.deltaTime * movementSpeed; 
        }

        else if (isInvulnerable)
        {
            transform.position += Vector3.up * Time.deltaTime * movementSpeed * 4; 
        }
    }

    public void DisplayPlayerHP ()
    {
        if(isDead)
        {
            hpText.text = "Dead";
            gameOverText.SetActive(true);
        }

        else
        {
            hpText.text = "Lives: " + currentHp.ToString();
        }
    }

    public void TakeDamage()
    {
        if (!isInvulnerable)
        {
            currentHp -= 1;
            
            if(currentHp <= 0)
            {
                isDead = true;
            }
        }
    }

    public void GainExtraLife()
    {
        currentHp += 1;
    }

    public void ModifyDashGauge()
    {
        if (dashPercent < 100)
        {
            dashPercent += 5;
            GetComponentInChildren<DashGauge>().SetDashBar(dashPercent);
        }
    }

    public void ActivateDash()
    {
        isInvulnerable = true;
        StartCoroutine(CO_DashTimer());
    }

    private IEnumerator CO_DashTimer()
    {
        yield return new WaitForSeconds(5f);
        isInvulnerable = false;
        dashPercent = 0;
        GetComponentInChildren<DashGauge>().SetDashBar(dashPercent);
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
