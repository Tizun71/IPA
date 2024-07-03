using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float startTime; 
    private float currentTime;

    public TextMeshProUGUI countdownText;
    public GameObject questionManager;
    public GameObject checkPanel;

    private bool isCheck = false;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (!isCheck)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                countdownText.text = currentTime.ToString("0");
            }
            else
            {
                currentTime = 0;
                countdownText.text = "Time's up!";
                Debug.Log(questionManager);
                checkPanel.SetActive(true);
                questionManager.GetComponent<QuestionManager>().pressCheck();
                isCheck = true;
            }
        }
    }
}
