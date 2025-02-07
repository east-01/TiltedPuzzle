using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SlideBox))]
public class TiltBoxController : MonoBehaviour
{

    [SerializeField]
    private float tiltDeadzone = 0.5f;

    private SlideBox box;

    void Awake()
    {
        box = GetComponent<SlideBox>();
    }

    void Update()
    {
        Vector2 dir = TouchBoxController.ApplyVectorFilter(Input.acceleration);
        Debug.Log($"box: {box.Dir} tilt: {dir}");
        if(dir.magnitude >= tiltDeadzone && box.Dir == Vector2.zero)
            box.Dir = dir;
    }

}
