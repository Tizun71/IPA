using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPath : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Awake()
    {
        text.text = Application.dataPath;
    }
}
