using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public ItemSlot itemSlot;
    public ChangeScene changeScene;
    public GameObject incorrectObject;
    public GameObject correctObject;
    public ScoreData scoreData;

    public TextMeshProUGUI currScore;

    public TextMeshProUGUI playerName;
    public TextMeshProUGUI crrnum;
    public TextMeshProUGUI score;
    public TextMeshProUGUI achievement;

    public GameObject boyAva;
    public GameObject girlAva;
    public void Awake()
    {
        correctObject.SetActive(false);
        incorrectObject.SetActive(false);
        currScore.text = scoreData.score.ToString();
        pushDataToScore();
    }

    public void pressContinue()
    {
        changeScene.Repeat();
        scoreData.corNum++;
        scoreData.score = scoreData.score + (scoreData.score + scoreData.corNum * 2) / 3 + Random.Range(1,6);
    }

    public void pressCheck()
    {
        if (itemSlot.checkAnswer())
        {
            correctObject.SetActive(true);
        }
        else
        {
            incorrectObject.SetActive(true);
        }
    }
    public void pushDataToScore()
    {
        playerName.text = scoreData.playerName;
        crrnum.text = "Số câu đúng: " + scoreData.corNum.ToString();
        score.text = "Điểm: " + scoreData.score.ToString();
        if (scoreData.score < 1000)
        {
            achievement.text = "Tân binh";
        }
        else if (scoreData.score < 10000)
        {
            achievement.text = "Cơ trưởng";
        }
        else
        {
            achievement.text = "Lão làng";
        }

        if (scoreData.gender)
        {
            boyAva.SetActive(true);
        }
        else
        {
            girlAva.SetActive(true);
        }
    }

    public void pushReset()
    {
        scoreData.corNum = 0;
        scoreData.score = 0;
        changeScene.Repeat();
    }
}
