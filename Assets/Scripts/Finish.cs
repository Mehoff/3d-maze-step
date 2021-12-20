using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    public GameObject triggerableObject;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Finish Collision!");

        if (other.gameObject.name == "Player")
        {
            finishSound.Play();

            if (triggerableObject)
            {
                var activationBase = triggerableObject.GetComponent<ActivationBase>();

                if (activationBase)
                    activationBase.Activate();
            }

        }
    }
}
