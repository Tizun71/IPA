using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PronounciationData : MonoBehaviour
{
    public int id { get; set; }
    public string name { get; set; }
    public string videoPath { get; set; }
    public string hintDescription { get; set; }

    public PronounciationData(PronounciationData x)
    {
        this.id = x.id;
        this.name = x.name;
        this.videoPath = x.videoPath;
        this.hintDescription = x.hintDescription;
    }

    public PronounciationData(int id, string name, string videoPath, string hintDescription)
    {
        this.id = id;
        this.name = name;
        this.videoPath = videoPath;
        this.hintDescription = hintDescription;
    }
}
