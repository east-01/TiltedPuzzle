using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBox : MonoBehaviour
{
    private TappableBoxCollider tbc;
    private Rigidbody2D rb;

    [SerializeField]
    private float forceScale = 200;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        tbc = GetComponent<TappableBoxCollider>();
    }

    private void Update()
    {
        if(tbc.Pressed) {
            Vector2 force = tbc.LatestTouch - new Vector2(transform.position.x, transform.position.y);
            force = BoxController.ApplyForceFilters(force, rb.velocity);
            rb.AddForce(force*forceScale);
        }
    }
}
