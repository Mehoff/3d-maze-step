using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject TriggerableObject;

    public AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Audio.Play();

        if (other.gameObject.name == "Player")
            TriggerableObject.GetComponent<ActivationBase>().Activate();


        CheckpointController.AddCheckPoint(GlobalTimer.getTimePassed());
    }
}
