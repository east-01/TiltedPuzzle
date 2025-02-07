using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideBox : MonoBehaviour
{
    private TappableBoxCollider tbc;
    private Rigidbody2D rb;

    [SerializeField]
    private float forceScale = 200;

    private Vector2 lastNonZeroDir;
    private Vector2 dir;
    public Vector2 Dir {
        get => dir;
        set {
            if(dir != Vector2.zero && value != Vector2.zero)  {
                Debug.LogError("Can't change TravelDir, it's currently sliding.");
                return;
            }
            if(value.magnitude > 0) {
                value = value.normalized;
                if(value == lastNonZeroDir) {
                    Debug.LogWarning("Almost duplicated");
                    return;
                }
                lastNonZeroDir = value;
            }

            dir = value;
            Debug.Log("set to: " + value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        tbc = GetComponent<TappableBoxCollider>();
    }

    private void FixedUpdate()
    {
        // Debug.Log("Dir: " + dir);
        if(Dir == Vector2.zero)
            rb.velocity = Vector2.zero;

        rb.AddForce(Dir*forceScale*Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        Dir = Vector2.zero;
        // rb.AddForce(-rb.velocity*1.1f, ForceMode2D.Impulse);
        // float mult = 1*forceScale*Time.fixedDeltaTime;
        // transform.position -= new Vector3(rb.velocity.x, rb.velocity.y, 0)*Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Killbox")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }  

    public enum TravelDir { NONE, UP, DOWN, LEFT, RIGHT }

}
