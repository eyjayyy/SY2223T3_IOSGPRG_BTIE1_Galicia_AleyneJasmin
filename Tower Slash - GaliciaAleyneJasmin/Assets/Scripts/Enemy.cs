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
    [SerializeField] private float movementSpeed; 
    [SerializeField] private float maxArrowSize = 0.005f;
    private int arrowDirection;
    private int swipeDirection;

    void Start()
    {
        enemyType = (EnemyTypes)Random.Range(0, System.Enum.GetValues(typeof(EnemyTypes)).Length);
        Debug.Log(enemyType);

        EvaluateEnemyType(enemyType);
        Debug.Log(arrowDirection);
    }

    void Update()
    {
        // Moves enemies downwards to mimic screen "moving"
        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * movementSpeed; 

        if (isAttacking == true) 
        {
            arrow.transform.localScale = new Vector3(maxArrowSize, maxArrowSize, maxArrowSize);
            arrowDirection = arrow.GetComponent<Arrow>().currentSprite;
            swipeDirection = player.GetComponentInChildren<SwipeControls>().directionIndex;
            KillEnemy(enemyType);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Destroy(this.gameObject);
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

    void KillEnemy (EnemyTypes type) 
    {
        if (type == EnemyTypes.GREEN || type == EnemyTypes.ROTATING)
        {
            if (swipeDirection == arrowDirection)
            {
                Destroy(this.gameObject);
                Debug.Log("Killed");
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
                        Destroy(this.gameObject);
                        Debug.Log("Killed");
                    }
                break;

                // Left Arrow
                case 1: 
                    // Swipe Right
                    if (swipeDirection == 3) 
                    {
                        Destroy(this.gameObject);
                        Debug.Log("Killed");
                    }
                break;

                // Up Arrow
                case 2: 
                    // Swipe Down
                    if (swipeDirection == 0) 
                    {
                        Destroy(this.gameObject);
                        Debug.Log("Killed");
                    }
                break;

                // Right Arrow
                case 3: 
                    // Swipe Left
                    if (swipeDirection == 1) 
                    {
                        Destroy(this.gameObject);
                        Debug.Log("Killed");
                    }
                break;
           }
        }
    }
}
