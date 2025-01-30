using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxController : MonoBehaviour
{

    [SerializeField]
    private float forceScale;
    // [SerializeField]
    // private float velocityForceAlignThreshold = 0.2f;

    // [SerializeField]
    // private float tiltDeadzone;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Create virtual force for testing
        float virtualHorizontal = 0;
        if(Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S)) {
            virtualHorizontal = Input.GetKey(KeyCode.W) ? 1 : -1;
        }

        float virtualVertical = 0;
        if(Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S)) {
            virtualVertical = Input.GetKey(KeyCode.W) ? 1 : -1;
        }

        
        Vector2 force = Input.acceleration + new Vector3(virtualHorizontal, virtualVertical);
        force = ApplyForceFilters(force, rb.velocity);

        if(force == Vector2.zero && rb.velocity.magnitude < 0.5f)
            rb.velocity = Vector2.zero;

        GetComponent<Rigidbody2D>().AddForce(Time.deltaTime*forceScale*force);
    }

    public static Vector2 ApplyForceFilters(Vector2 force, Vector2 velocity) 
    {
        // Only allow the force to go along one direction at a time.
        if(Math.Abs(force.x) > Math.Abs(force.y)) {
            force = new(force.x, 0);
        } else {
            force = new(0, force.y);
        }

        // Ensure the force applied is aligned with the velocity, only if the velocity is high enough
        if(velocity.magnitude > 0.2f) {
            bool aligned = force.normalized - velocity.normalized == Vector2.zero;
            if(!aligned)
                return Vector2.zero;
        }

        // Debug.Log("mag: " + force.magnitude);

        if(force.magnitude < 0.075f) {
            return Vector2.zero;
        }

        return force;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Killbox")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }  

}
