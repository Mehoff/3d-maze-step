using UnityEngine;

public class Rotate : ActivationBase
{
    public float units = 30f;
    private bool Activated = false;
    public override void Activate()
    {
        this.Activated = true;
    }


    private void Update()
    {
        if (Activated)
            transform.RotateAround(transform.position, Vector3.up, units * Time.deltaTime);
    }
}
