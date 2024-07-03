using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public CSVFrameReader reader;
    public ListFrameData data;
    public string framesPath;

    public string filePath;
    public Data DataSO;
    private CSVReader CSVreader;
    private void Awake()
    {
        reader = reader.getInstance();
        reader.pushData(framesPath);

        CSVreader = CSVReader.getInstance(filePath);
    }

    public void importDataToMainPage(int id)
    {
        DataSO.audioUrl.Clear();
        DataSO.imageUrl.Clear();
        DataSO.pronounceText.Clear();
        DataSO.meaningText.Clear();
        DataSO.VNText.Clear();
        importData(id + 1);
    }

    private void importData(int id)
    {
        PronounciationData tmp = CSVreader.getData(id);
        DataSO.id = tmp.id;
        DataSO.name = tmp.name;
        DataSO.videoPath = tmp.videoPath;
        DataSO.hintDescription = tmp.hintDescription;

        List<FrameData> ftmp = reader.getList(id);
        foreach (var item in ftmp)
        {
            DataSO.audioUrl.Add(item.audioUrl);
            DataSO.imageUrl.Add(item.imageUrl);
            DataSO.pronounceText.Add(item.pronounceText);
            DataSO.meaningText.Add(item.meaningText);
            DataSO.VNText.Add(item.vntext);
        }
    }
}
