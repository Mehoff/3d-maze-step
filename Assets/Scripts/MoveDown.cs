using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : ActivationBase
{
    public float coords;
    public AudioSource Audio;

    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;
    bool isActivated = false;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        startPosition = target = transform.position;
        coords = 1.30f;
    }
    public override void Activate()
    {
        isActivated = true;
        Audio.Play();
        var pos = this.transform.position;
        SetDestination(new Vector3(pos.x, pos.y + coords, pos.z), 3f);
    }

    void Update()
    {
        if (isActivated)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }
    }

    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }
}
