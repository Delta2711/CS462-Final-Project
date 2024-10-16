using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    public GameObject myLight;
    Light lt;

    void Start()
    {
        lt = myLight.GetComponent<Light>();
    }

    public void Toggle()
    {
        Debug.Log("Trying to toggle the light.");
        lt.enabled = !lt.enabled;
        
    }

}
