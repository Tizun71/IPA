using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameData : MonoBehaviour
{
    public int id { get; set; }
    public string audioUrl { get; set; }
    public string imageUrl { get; set; }
    public string pronounceText { get; set; }
    public string meaningText { get; set; }

    public string vntext { get; set; }

    public FrameData(int id, string audioUrl, string imageUrl, string pronounceText, string meaningText, string vntxt)
    {
        this.id = id;
        this.audioUrl = audioUrl;
        this.imageUrl = imageUrl;
        this.pronounceText = pronounceText;
        this.meaningText = meaningText;
        this.vntext = vntxt;
    }
}
