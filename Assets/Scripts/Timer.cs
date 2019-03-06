using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float time = 300;
    public int score = 0;
    public int answeredQuestions = 0;
    public int maxScore = 10;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoundownTimer();
        score = 0;
    }

    private void StartCoundownTimer()
    {
        if (timerText != null)
        {
            timerText.text = "05:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    // Update is called once per frame
    private void UpdateTimer()
    {
        scoreText.text = "Score: " + score + "/" + answeredQuestions;

        if (timerText != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string fraction = ((time * 100) % 100).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }

        if (time <= 0)
        {
            CancelInvoke();
            timerText.text = "Game Over";
        }

        if (score >= maxScore)
        {
            Debug.Log("End Game");
        }
    }
}