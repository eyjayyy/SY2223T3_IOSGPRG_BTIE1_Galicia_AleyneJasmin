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
    public int arrowDirection;
    public Player player;
    [SerializeField] private float movementSpeed; 

    void Start()
    {
        enemyType = (EnemyTypes)Random.Range(0, System.Enum.GetValues(typeof(EnemyTypes)).Length);
        Debug.Log(enemyType);

        EvaluateEnemyType(enemyType);
        Debug.Log("Swipe is " + player.GetComponentInChildren<SwipeControls>().swipeDirection);
        arrowDirection = arrow.GetComponent<Arrow>().currentSprite;
        Debug.Log(arrowDirection);

    }

    void Update()
    {
        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * movementSpeed;
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Destroy(gameObject);
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

    }


}
