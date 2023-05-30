using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum EnemyTypes
    {
        GREEN,
        RED
    }

    public EnemyTypes enemyType;
    public GameObject arrow;
    public Player player;
    public bool isAttacking;
    [SerializeField] private float movementSpeed; 
    [SerializeField] private float maxArrowSize = 0.005f;
    private int arrowDirection;
    private int swipeDirection;

    void Start()
    {
        arrowDirection = arrow.GetComponent<Arrow>().currentSprite;
        enemyType = (EnemyTypes)Random.Range(0, System.Enum.GetValues(typeof(EnemyTypes)).Length);
        Debug.Log(enemyType);

        EvaluateEnemyType(enemyType);
        Debug.Log(arrowDirection);

    }

    void Update()
    {
        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * movementSpeed; //Moves enemies downwards to mimic screen "moving"

        if (isAttacking == true) 
        {
            arrow.transform.localScale = new Vector3(maxArrowSize, maxArrowSize, maxArrowSize);
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
                arrow.GetComponent<Image>().color = new Color(0, 1, 0, 1);         
            break;

            case EnemyTypes.RED:
                arrow.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            break;
        }
    }

    void KillEnemy (EnemyTypes type) 
    {
        if (type == EnemyTypes.GREEN)
        {
            if (swipeDirection == arrowDirection)
            {
                Destroy(this.gameObject);
            }
        }

        else if (type == EnemyTypes.RED) //Opposite direction
        {
           switch(arrowDirection)
           {
                case 0: //Down Arrow
                    if (swipeDirection == 3) //Swipe Up
                    {
                        Destroy(this.gameObject);
                    }
                break;

                case 1: //Left Arrow
                    if (swipeDirection == 2) //Swipe Right
                    {
                        Destroy(this.gameObject);
                    }
                break;

                case 2: //Right Arrow
                    if (swipeDirection == 1) //Swipe Left
                    {
                        Destroy(this.gameObject);
                    }
                break;

                case 3: //Up Arrow
                    if (swipeDirection == 0) //Swipe Up
                    {
                        Destroy(this.gameObject);
                    }
                break;
           }
        }
    }
}
