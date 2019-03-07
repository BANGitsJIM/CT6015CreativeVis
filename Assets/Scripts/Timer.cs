using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float time = 300;
    public float score = 0;
    public float answeredQuestions = 0;
    public float maxScore = 10;
    public float minAnswersToPass;
    public float passRate;
    public TMP_Text scoreText;
    public TMP_Text gameOverScoreText;
    public TMP_Text gameOverResult;
    public TMP_Text hintText;
    public GameObject gameOverScreen;

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
            if (SceneManager.GetActiveScene().name == "Question")
            {
                SceneManager.UnloadSceneAsync("Question");
            }

            GameOver();
        }

        if (answeredQuestions >= maxScore)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        CancelInvoke();
        timerText.text = "Game Over";
        gameOverScoreText.text = "YOU SCORED " + score + "/" + answeredQuestions;

        float percentageObtained = ((score / answeredQuestions) * 100);
        string myPercent = percentageObtained.ToString("F0");

        if (score / answeredQuestions * 100 >= passRate && answeredQuestions >= minAnswersToPass)
        {
            gameOverResult.text = "You Passed";
            gameOverResult.color = new Color32(60, 233, 50, 255);
        }
        else
        {
            gameOverResult.text = "You Failed";
            gameOverResult.color = new Color32(250, 40, 40, 255);
        }

        if (answeredQuestions < minAnswersToPass)
        {
            hintText.text = "You required to answer at least " + minAnswersToPass + " questions to pass, you answered " + answeredQuestions + "!";
        }
        else if (score / answeredQuestions * 100 < passRate)
        {
            hintText.text = "The pass rate for this test is " + passRate + "% you got " + myPercent + "%";
        }
        else
        {
            hintText.text = "Well done! You required " + passRate + "% and you scored " + myPercent + "%";
        }

        gameOverScreen.SetActive(true);
    }
}