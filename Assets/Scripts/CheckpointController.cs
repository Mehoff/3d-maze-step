using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static List<float> CheckpointTimestamps = new List<float>();
    public static void AddCheckPoint(float time)
    {
        CheckpointTimestamps.Add(time);
    }

    public static void SaveCheckpointFile()
    {
        var date = DateTime.Now;
        var name = $"/Record_{date.ToBinary()}.txt";

        string path = Application.persistentDataPath + name;

        Debug.Log("Рекорд сохранён по пути: " + path);

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine("Date: " + DateTime.Now.ToLongDateString() + "\n");

        for (int i = 0; i < CheckpointTimestamps.Count; i++)
        {
            string checkpointString = GlobalTimer.ConvertToTimeString(CheckpointTimestamps[i]);
            writer.WriteLine($"{i + 1}. {checkpointString}\n");
        }

        writer.Close();
    }
}
