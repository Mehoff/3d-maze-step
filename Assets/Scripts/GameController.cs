using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isPaused;
    public Canvas UIPause;
    private void Start()
    {
        isPaused = false;
        UIPause.enabled = false;

        UnityEngine.UI.Button ButtonResume = UIPause.transform.GetChild(0).GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Button ButtonRestart = UIPause.transform.GetChild(1).GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Button ButtonExit = UIPause.transform.GetChild(2).GetComponent<UnityEngine.UI.Button>();


        Debug.Log(ButtonRestart.name);
        Debug.Log(ButtonExit.name);


        ButtonResume.onClick.AddListener(ButtonResumeClickHandler);
        ButtonRestart.onClick.AddListener(ButtonRestartClickHandler);
        ButtonExit.onClick.AddListener(ButtonExitClickHandler);
    }

    private void ButtonResumeClickHandler()
    {
        this.SetPause(false);
    }

    private void ButtonRestartClickHandler()
    {
        this.SetPause(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ButtonExitClickHandler()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            this.SetPause(isPaused);
        }
    }
    public void SetPause(bool value)
    {
        isPaused = value;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            UIPause.enabled = true;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            UIPause.enabled = false;
            Time.timeScale = 1f;
        }
    }
}