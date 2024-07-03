using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "IPA")]
public class Data : ScriptableObject
{
    public int id;
    public string name;
    public string videoPath;
    public string hintDescription;
    public List<string> audioUrl;
    public List<string> imageUrl;
    public List<string> pronounceText;
    public List<string> meaningText;
    public List<string> VNText;
}
