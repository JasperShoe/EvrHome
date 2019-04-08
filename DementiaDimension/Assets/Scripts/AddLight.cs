using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLight : MonoBehaviour
{
    GameObject lightObject;
    Light lightComponent;

    void Start()
    {
        lightObject = new GameObject("Light");
        lightComponent = lightObject.AddComponent<Light>();
        lightComponent.color = Color.white;
        lightComponent.transform.position = transform.position;
        lightComponent.intensity = (float)0.75;
    }

    void Update()
    {
        
    }
}
