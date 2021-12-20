using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public static float timePassed { get; set; }

    public TextMeshProUGUI textMesh;

    public static bool isPaused;


    void Start()
    {
        isPaused = false;
        timePassed = 0f;
    }
    void Update()
    {
        if (!isPaused)
        {
            timePassed += Time.deltaTime;
            textMesh.text = ConvertToTimeString(timePassed);
        }
    }
    public void Pause()
    {
        isPaused = false;
    }
    public static string ConvertToTimeString(float value)
    {
        float minutes = Mathf.FloorToInt(value / 60);
        float seconds = Mathf.FloorToInt(value % 60);

        var sb = new StringBuilder();

        if (minutes < 10.0f)
        {
            sb.Append("0");
        }

        sb.Append(minutes + ":");


        if (seconds < 10.0f)
        {
            sb.Append("0");
        }

        sb.Append(seconds);

        string result = sb.ToString();
        return result;
    }

    public static float getTimePassed()
    {
        return timePassed;
    }
}