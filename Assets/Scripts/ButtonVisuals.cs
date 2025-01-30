using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVisuals : MonoBehaviour
{
    [SerializeField]
    private GameObject pressedImage;
    [SerializeField]
    private GameObject releasedImage;

    private TappableBoxCollider tbc;

    private void Awake()
    {
        tbc = GetComponent<TappableBoxCollider>();
    }

    private void Update() 
    {
        pressedImage.SetActive(tbc.Pressed);
        releasedImage.SetActive(!tbc.Pressed);
    }
}
