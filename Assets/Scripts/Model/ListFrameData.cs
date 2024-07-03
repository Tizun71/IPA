using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List Frame Data", menuName = "IPA Frame")]
public class ListFrameData : ScriptableObject
{
    public List<FrameData> frames;
}
