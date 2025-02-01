using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableButtonSound : MonoBehaviour
{
    [SerializeField]
    private TappableBoxCollider button;

    [SerializeField]
    private AudioSource clickInSource;
    [SerializeField]
    private AudioSource clickOutSource;

    private bool lastPressedValue;

    private void Update() 
    {
        if(button == null) {
            Debug.LogError("ObservableButtonSound cannot function without button being assigned.");
            return;
        }        

        if(lastPressedValue != button.Pressed) {
            if(button.Pressed) {
                clickInSource.Play();
            } else {
                clickOutSource.Play();
            }
        }

        lastPressedValue = button.Pressed;
    }
}
