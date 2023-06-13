using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public enum SwipeDirection
    {
        DOWN,
        LEFT,
        UP,
        RIGHT
    }

    public SwipeDirection swipeDirection;
    public Player player;
    public int directionIndex;
    private Vector2 initialTouchPosition;
    private Vector2 endTouchPosition;

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
        // Vertical movement is greater
        if (Mathf.Abs(endTouchPosition.y - initialTouchPosition.y) > Mathf.Abs(endTouchPosition.x - initialTouchPosition.x))
        {
            if (endTouchPosition.y >= initialTouchPosition.y) 
            {
                swipeDirection = SwipeDirection.UP;
            }

            else
            {
                swipeDirection = SwipeDirection.DOWN;
            }
        }

        // Horizontal movement is greater
        else 
        {
            if (endTouchPosition.x >= initialTouchPosition.x)
            {
                swipeDirection = SwipeDirection.RIGHT;
            }

            else
            {
                swipeDirection = SwipeDirection.LEFT;
            }
        }

        directionIndex = (int)swipeDirection;
        Debug.Log(swipeDirection + " Index is " + directionIndex);
    }
}
