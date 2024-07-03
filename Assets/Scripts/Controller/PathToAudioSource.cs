using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PathToAudioSource : MonoBehaviour
{
    public AudioSource audio;
    public RandomQuestion randomQuestion;
    IEnumerator LoadMP3FromURL(string relativePath)
    {
        string url = Application.dataPath + '/' + relativePath;
        Debug.Log(url);
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

    public void Start()
    {
        StartCoroutine(LoadMP3FromURL("Source/List/audio/" + randomQuestion.audioAnswer));
    }
}
