using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVReader : MonoBehaviour
{
    private List<PronounciationData> list = new List<PronounciationData>();
    private static CSVReader _instance;

    private CSVReader(string filePath)
    {
        if (filePath == null)
        {
            return;
        }
        filePath = Application.dataPath + filePath;
        using (StreamReader sr = new StreamReader(filePath))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] row = new string[4];
                row = line.Split(',');
                int id = int.Parse(row[0]);
                string name = row[1];
                string videoPath = row[2];
                string hintDescription = row[3];
                list.Add(new PronounciationData(id, name, videoPath, hintDescription));
            }
        }
    }
    public static CSVReader getInstance(string filePath)
    {
        if (_instance == null)
        {
            _instance = new CSVReader(filePath);
        }
        return _instance;
    }
    public PronounciationData getData(int id)
    {
        foreach (PronounciationData data in list)
        {
            if (data.id == id)
            {
                return data;
            }
        }
        return null;
    }
}
