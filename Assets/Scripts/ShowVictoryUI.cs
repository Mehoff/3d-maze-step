using System.Collections;
using TMPro;
using UnityEngine;

public class ShowVictoryUI : ActivationBase
{
    public bool isActivated = false;

    public TextMeshProUGUI victoryTextObject;

    public override void Activate()
    {
        victoryTextObject.gameObject.SetActive(true);

        CheckpointController.SaveCheckpointFile();

        GlobalTimer.isPaused = true;

        StartCoroutine(HideVictoryText());
    }


    private IEnumerator HideVictoryText()
    {
        yield return new WaitForSeconds(5f);
        victoryTextObject.gameObject.SetActive(false);
    }
}