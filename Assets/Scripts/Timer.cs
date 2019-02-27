using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float time = 300;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoundownTimer();
    }

    private void StartCoundownTimer()
    {
        if (timerText != null)
        {
            time = 10;
            timerText.text = "05:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    // Update is called once per frame
    private void UpdateTimer()
    {
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
    }
}