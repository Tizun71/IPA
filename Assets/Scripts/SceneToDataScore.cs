using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneToDataScore : MonoBehaviour
{
    public ScoreData scoreData;

    public Button avaBoy;
    public Button avaGirl;
    public TextMeshProUGUI inputField;

    private void Awake()
    {
        scoreData.corNum = 0;
        scoreData.score = 0;
    }

    public void pressAvaBoy()
    {
        ColorBlock cb = avaBoy.colors;
        Color nc = cb.normalColor;
        nc.a = 1f;
        cb.normalColor = nc;
        avaBoy.colors = cb;

        ColorBlock cb2 = avaGirl.colors;
        Color nc2 = cb2.normalColor;
        nc2.a = 0.5f;
        cb2.normalColor = nc2;
        avaGirl.colors = cb2;

        scoreData.gender = true;
    }

    public void pressAvaGirl()
    {
        ColorBlock cb = avaBoy.colors;
        Color nc = cb.normalColor;
        nc.a = 0.5f;
        cb.normalColor = nc;
        avaBoy.colors = cb;

        ColorBlock cb2 = avaGirl.colors;
        Color nc2 = cb2.normalColor;
        nc2.a = 1f;
        cb2.normalColor = nc2;
        avaGirl.colors = cb2;

        scoreData.gender = false;
    }

    public void getInputValue()
    {
        string inputValue = inputField.text;
        scoreData.playerName = inputValue;
    }
}
