using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    [SerializeField]
    private TappableBoxCollider observed;
    [SerializeField]
    private bool invertObserved;
    [SerializeField]
    private GameObject killbox;

    private void Update()
    {

        bool observed = this.observed.Pressed;
        if(invertObserved)
            observed = !observed;

        GetComponent<TappableBoxCollider>().overridePressedValue = observed;
        killbox.SetActive(observed);
    }
}
