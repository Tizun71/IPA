using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Score Data", menuName = "IPA Score")]
public class ScoreData : ScriptableObject
{
    public string playerName;
    public bool gender;
    public int corNum;
    public int score;
    [SerializeField] private string achievement;
}
