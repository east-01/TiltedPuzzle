using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SlideBox))]
public class TouchBoxController : MonoBehaviour
{
    [SerializeField]
    private float minSwipeDistance = 0.2f;

    private SlideBox box;
    private new Collider2D collider2D;
    private Vector2 startPos;
    private bool isTouchValid;


    void Awake()
    {
        box = GetComponent<SlideBox>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            // The following is ChatGPT code- I made these changes close to before the deadline
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    isTouchValid = collider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(startPos));
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (isTouchValid)
                    {
                        Vector2 currentPos = touch.position;
                        Vector2 moveVector = currentPos - startPos;
                        moveVector = ApplyVectorFilter(moveVector);

                        if (moveVector.magnitude > minSwipeDistance)
                        {
                            box.Dir = moveVector;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isTouchValid = false;
                    break;
            }
        }
    }

    /// <summary>
    /// Takes the bigger of the two vectors in the cardinal directions- so if the angle of the vector
    ///   is 20 degrees it would return a right vector in the scale of the x axis.
    /// </summary>
    public static Vector2 ApplyVectorFilter(Vector2 force) 
    {
        // Only allow the force to go along one direction at a time.
        if(Math.Abs(force.x) > Math.Abs(force.y)) {
            force.y = 0;
        } else {
            force.x = 0;
        }
        return force;
    }
}
