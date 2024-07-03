using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class PushDataToFrame : MonoBehaviour
{
    public Data data;

    public Image image;
    public TextMeshProUGUI pronounceText;
    public TextMeshProUGUI meaningText;
    public TextMeshProUGUI VNText;
    public AudioSource audio;
    int index;

    private void Awake()
    {

    }

    private void Start()
    {
        index = 0;
        displayFrame();
    }
    public void LoadImageFromFile(string relativePath)
    {
        // Combine the base path with the relative path
        string fullPath = Application.dataPath + '/' + relativePath;
        Debug.Log(fullPath);

        if (File.Exists(fullPath))
        {
            byte[] fileData = File.ReadAllBytes(fullPath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            image.sprite = newSprite;
        }
        else
        {
            Debug.LogError("File not found at " + fullPath);
        }
    }

    IEnumerator LoadMP3FromURL(string relativePath)
    {
        string url = Application.dataPath + '/' + relativePath;
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to load MP3 file: " + www.error);
            }
            else
            {
                // Get the downloaded audio clip
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(www);

                // Assign the audio clip to the audio source
                audio.clip = audioClip;

                // Play the audio clip
            }
        }
    }

    private void displayFrame()
    {
        LoadImageFromFile("Source/List/img/" + data.imageUrl[index]);
        pronounceText.text = data.pronounceText[index];
        meaningText.text = data.meaningText[index];
        VNText.text = data.VNText[index];
        //LoadAudioFromFile("Source/List/audio/" + data.audioUrl[index]);
        StartCoroutine(LoadMP3FromURL("Source/List/audio/" + data.audioUrl[index]));
    }

    public void pressNext()
    {
        index++;
        if (index >= data.imageUrl.Count)
        {
            index = 0;
        }
        displayFrame();
    }

    public void pressPrev()
    {
        index--;
        if (index < 0)
        {
            index = data.imageUrl.Count - 1;
        }
        displayFrame();
    }
}
