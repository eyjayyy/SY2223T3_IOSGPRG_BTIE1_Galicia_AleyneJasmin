using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum EnemyTypes
    {
        GREEN,
        RED,
        ROTATING
    }

    public EnemyTypes enemyType;
    public Arrow arrow;
    public Player player;
    public bool isAttacking;
    [SerializeField] private float maxArrowSize = 0.005f;
    private int arrowDirection;
    private int swipeDirection;
    private bool isCorrectSwipe;

    void Start()
    {
        enemyType = (EnemyTypes)Random.Range(0, System.Enum.GetValues(typeof(EnemyTypes)).Length);
        Debug.Log(enemyType);

        EvaluateEnemyType(enemyType);
        Debug.Log(arrowDirection);
    }

    void Update()
    {
        if (isAttacking == true) 
        {
            arrow.transform.localScale = new Vector3(maxArrowSize, maxArrowSize, maxArrowSize);
            arrowDirection = arrow.GetComponent<Arrow>().currentSprite;
            swipeDirection = player.GetComponentInChildren<SwipeControls>().directionIndex;
            EvaluateSwipeAndArrow(enemyType);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (player.isInvulnerable)
        {
            KillEnemy();
        }

        else
        {
            player.TakeDamage();
            DestroyEnemy();
            Debug.Log("Hit!");
        }
    }

    void DestroyEnemy()
    {
        player.DisplayPlayerHP();
        Destroy(this.gameObject);
        EnemySpawner.Instance.RemoveEnemyFromList(this.gameObject);
    }

    void CheckForPowerUp()
    {
        int powerupChance = Random.Range(1, 101);
        Debug.Log("Chance: " + powerupChance);

        if (powerupChance <= 3)
        {
            player.GainExtraLife();
            player.DisplayPlayerHP();
            Debug.Log("Extra life");
        }
    }

    void KillEnemy()
    {
        DestroyEnemy();
        CheckForPowerUp();
        player.ModifyDashGauge();
        Debug.Log("Killed");
    }

    void EvaluateEnemyType (EnemyTypes type)
    {   
        switch(type)
        {
            case EnemyTypes.GREEN:
                arrow.GetComponent<Image>().color = Color.green;       
                arrow.GetArrow();  
            break;

            case EnemyTypes.RED:
                arrow.GetComponent<Image>().color = Color.red;
                arrow.GetArrow();
            break;

            case EnemyTypes.ROTATING:
                StartCoroutine(arrow.CO_RotateArrow());
            break;
        }
    }

    void EvaluateSwipeAndArrow (EnemyTypes type) 
    {
        if (type == EnemyTypes.GREEN || type == EnemyTypes.ROTATING)
        {
            if (swipeDirection == arrowDirection)
            {
                KillEnemy();
            }
        }

        // Opposite direction
        else if (type == EnemyTypes.RED) 
        {
           switch(arrowDirection)
           {
                // Down Arrow
                case 0: 
                    // Swipe Up
                    if (swipeDirection == 2) 
                    {
                        KillEnemy();
                    }
                break;

                // Left Arrow
                case 1: 
                    // Swipe Right
                    if (swipeDirection == 3) 
                    {
                        KillEnemy();
                    }
                break;

                // Up Arrow
                case 2: 
                    // Swipe Down
                    if (swipeDirection == 0) 
                    {
                        KillEnemy();
                    }
                break;

                // Right Arrow
                case 3: 
                    // Swipe Left
                    if (swipeDirection == 1) 
                    {
                        KillEnemy();
                    }
                break;
           }
        }
    }
}
