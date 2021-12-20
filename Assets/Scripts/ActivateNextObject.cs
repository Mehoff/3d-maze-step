using UnityEngine;

public class ActivateNextObject : ActivationBase
{
    public GameObject Next;
    private bool Activated;

    private void Start()
    {
        Activated = false;
    }
    public override void Activate()
    {

        Debug.Log($"This: {this.name}; Activate {Next.name}");
        // if(!Activated){
        //     Activated = !Activated;
        //     Next.GetComponent<Button>()
        // }
    }
}
