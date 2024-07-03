using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;

public class ImportDataIntoPronounciationScene : MonoBehaviour
{
    public Data data;
    public VideoPlayer videoPlayer;
    public TextMeshProUGUI textObject;

    public void Awake()
    {
        if (videoPlayer == null)
        {
            return;
        }
        ChangeVideo();
        ChangeTextHint();
    }

    public void ChangeVideo()
    {
        if (!string.IsNullOrEmpty(data.videoPath))
        {
            //string urlVideo = "Assets/Source/PronounciationVideo/" + data.videoPath;
            string urlVideo = Application.dataPath + "/Source/PronounciationVideo/" + data.videoPath;
            videoPlayer.url = urlVideo;
        }
        else
        {
            videoPlayer.url = null;
        }
    }

    public void ChangeTextHint()
    {
        if (!string.IsNullOrEmpty(data.hintDescription))
        {
            textObject.text = data.hintDescription;
        }
        else
        {
            textObject.text = "";
        }
    }
}
