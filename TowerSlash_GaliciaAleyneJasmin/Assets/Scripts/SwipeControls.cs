using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public enum SwipeDirection
    {
        DOWN,
        LEFT,
        RIGHT,
        UP
    }

    public SwipeDirection swipeDirection;
    public Player player;
    public int directionIndex;
    private Vector2 initialTouchPosition;
    private Vector2 endTouchPosition;
    private float deadZone = 100;

    void Update()
    {
        if (player.inRange)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0);
                initialTouchPosition = touch.position;
            } 

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Touch touch = Input.GetTouch(0);
                endTouchPosition = touch.position;

                CheckSwipe();
            }
        }
    }

    private void CheckSwipe()
    {
        if (endTouchPosition.y - initialTouchPosition.y > endTouchPosition.x - initialTouchPosition.x) //Vertical movement is greater
        {
            if (endTouchPosition.y >= initialTouchPosition.y + deadZone) 
            {
                swipeDirection = SwipeDirection.UP;
            }

            else
            {
                swipeDirection = SwipeDirection.LEFT;
            }
        }

        else //Horizontal movement is greater
        {
            if (endTouchPosition.x >= initialTouchPosition.x + deadZone)
            {
                swipeDirection = SwipeDirection.RIGHT;
            }

            else
            {
                swipeDirection = SwipeDirection.DOWN;
            }
        }

        directionIndex = (int)swipeDirection;
        Debug.Log(swipeDirection + " Index is " + directionIndex);
    }
}
