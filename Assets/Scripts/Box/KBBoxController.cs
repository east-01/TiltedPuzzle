using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SlideBox))]
public class KBBoxController : MonoBehaviour
{

    private SlideBox box;

    void Awake()
    {
        box = GetComponent<SlideBox>();
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

        Vector2 dir = new(virtualHorizontal, virtualVertical);
        if(dir.magnitude > 0.1 && box.Dir == Vector2.zero)
            box.Dir = dir;
    }

}
