using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocitySound : MonoBehaviour
{
    [SerializeField]
    private AudioSource slideSource;
    [SerializeField]
    private AudioSource stopSource;
    private Rigidbody2D rb;

    [SerializeField]
    private float velocityMagThreshold;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Debug.Log("playing: " + src.isPlaying + " vel mag: " + rb.velocity.magnitude + " thresh: " + velocityMagThreshold);
        if(!slideSource.isPlaying && rb.velocity.magnitude > velocityMagThreshold) {
            slideSource.Play();
        } else if (slideSource.isPlaying && rb.velocity.magnitude <= velocityMagThreshold) {
            slideSource.Stop();
            stopSource.Play();
        }
    }
}
