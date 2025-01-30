using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappableBoxCollider : MonoBehaviour
{
    private new BoxCollider2D collider2D;

    [Header("FOR TESTING: Allows you to override the state of this button")]
    public bool overrideState = false;
    public bool overridePressedValue = true;

    private bool pressed;
    public bool Pressed {
        get => pressed;
        private set {
            pressed = value;
        }
    }

    public Vector2 LatestTouch { get; private set; }
    public Touch Culprit { get; private set; }

    [SerializeField]
    private bool isPressed; // readout

    private void Awake() 
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        isPressed = Pressed;
        if(overrideState) {
            Pressed = overridePressedValue;
            return;
        }

        bool contains = false;
        for(int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            LatestTouch = touch.position;
            LatestTouch = Camera.main.ScreenToWorldPoint(LatestTouch);
            Culprit = touch;
            contains = collider2D.bounds.Contains(LatestTouch);
            if(contains)
                break;
        }
        Pressed = contains;
    }
}
