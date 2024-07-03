using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQuestion : MonoBehaviour
{
    [SerializeField] private CSVFrameReader reader;
    List<FrameData> datas = new List<FrameData> ();
    public string filePath;
     public string imageAnswer { get; set; }
     public string audioAnswer { get; set; }
    public int idFrameCorrect { get; set; }

    public void Awake()
    {
        reader.pushData(filePath);
        datas = reader.getFullList();
        getQuestion();
    }

    public void getQuestion()
    {
        int ran = Random.Range(0, datas.Count);
        imageAnswer = datas[ran].imageUrl;
        audioAnswer = datas[ran].audioUrl;
        new WaitForSeconds(1f);
        idFrameCorrect = Random.Range(1, 7);
    }

    public string getRandomImage()
    {
        string url = null;
        do
        {
            int ran = Random.Range(0, datas.Count);
            url = datas[ran].imageUrl;
        }
        while (url == imageAnswer);
        return url;
    }
}
