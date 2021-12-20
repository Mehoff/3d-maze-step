using UnityEngine;
using UnityEngine.UI;

public class SequenceButton : ActivationBase
{
    public SequenceController sequenceController;
    public bool Activated;

    public AudioSource Audio;
    private Text text;
    public int index;


    private void Start()
    {
        Activated = false;
        Audio = GetComponent<AudioSource>();
        text = (UnityEngine.UI.Text)this.gameObject.GetComponentInChildren(typeof(UnityEngine.UI.Text), true);
    }
    public override void Activate()
    {
        Audio.Play();
        if (!Activated)
        {
            sequenceController.HandleButtonClick(index);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            this.Activate();
            //Player.AddPoints(1);
        }
    }

    public void ChangeLookByActivateState()
    {
        if (Activated)
        {
            text.color = Color.green;
            text.text = "OK";
        }
        else
        {
            text.color = Color.red;
            text.text = (index + 1).ToString();
        }
    }
    public void Deactivate()
    {
        if (Activated)
        {
            Activated = false;
            ChangeLookByActivateState();
        }
    }
}
