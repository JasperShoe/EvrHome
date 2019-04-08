using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactives : MonoBehaviour
{
    GameObject lightObject;

    GameObject audioObject;

    Light lightComponent;

    Behaviour halo;

    MeshCollider meshCollider;

    AudioSource audioSource;


    void Start()
    {
        meshCollider = this.gameObject.AddComponent<MeshCollider>();

        lightObject = new GameObject("Light");

        lightComponent = lightObject.AddComponent<Light>();
        lightComponent.intensity = (float)1.5;
        lightComponent.range = 3;
        lightComponent.color = Color.green;
        lightComponent.transform.position = transform.position;
        lightComponent.transform.position = meshCollider.bounds.center;
        lightObject.active = false;

        //audioObject = new GameObject("Audio");
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().playOnAwake = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
        audioSource.Pause();
    }

    void Update()
    {
        Interact();
    }

    void Interact()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hit) && meshCollider.bounds.Contains(hit.point))
        {
            lightObject.active = true;
            audioSource.UnPause();
        }
        else
        {
            lightObject.active = false;
            audioSource.Pause();
        }
    }
}
