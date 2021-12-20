using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public GameObject ActivationTarget;
    public List<SequenceButton> buttonSequence;

    private void ResetButtons()
    {
        foreach (var button in buttonSequence)
        {
            button.Deactivate();
        }
    }

    private bool isAllActivated()
    {
        return this.buttonSequence.Count(b => b.Activated) == this.buttonSequence.Count;
    }

    private void Finish()
    {
        ActivationTarget.GetComponent<ActivationBase>().Activate();
    }

    public void HandleButtonClick(int index)
    {

        for (int i = 0; i < index; i++)
        {
            if (buttonSequence[i].Activated)
                continue;
            else
            {
                ResetButtons();
                return;
            }
        }

        buttonSequence[index].Activated = true;
        buttonSequence[index].ChangeLookByActivateState();


        if (isAllActivated())
            Finish();
    }
}
