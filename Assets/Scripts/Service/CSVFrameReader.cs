using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVFrameReader : MonoBehaviour
{
    private List<FrameData> frames = new List<FrameData>();
    private static CSVFrameReader _instance;

    public CSVFrameReader getInstance()
    {
        if (_instance == null)
            _instance = new CSVFrameReader();
        return _instance;
    }
    public void pushData(string filePath)
    {
        if (filePath == null)
        {
            return;
        }
        filePath = Application.dataPath + filePath;
        Debug.Log(filePath);
        using (StreamReader sr = new StreamReader(filePath))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] row = new string[6];
                row = line.Split(',');
                int id = int.Parse(row[0]);
                string audioUrl = row[1];
                string imageUrl = row[2];
                string pronounceText = row[3];
                string meaningText = row[4];
                string vntext = row[5];

                frames.Add(new FrameData(id, audioUrl, imageUrl, pronounceText, meaningText, vntext));
            }
        }
    }

    public List<FrameData> getList(int id)
    {
        List<FrameData> tmp = new List<FrameData>();
        foreach (FrameData frame in frames)
        {
            if (frame.id == id)
            {
                tmp.Add(frame);
            }

        }
        return tmp;
    }

    public List<FrameData> getFullList()
    {
        return frames;
    }
}
