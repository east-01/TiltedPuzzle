using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour
{
    private TappableBoxCollider tbc;

    private void Awake()
    {
        tbc = GetComponent<TappableBoxCollider>();
        tbc.overrideState = true;
        tbc.overridePressedValue = false;
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        tbc.overridePressedValue = false;
        Debug.Log("Set to false");
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        Debug.Log("Trigger stay called");
        tbc.overridePressedValue = true;
    }

}
