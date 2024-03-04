using UnityEngine;
using System.Collections;
using TMPro;

public class FadeTimer : MonoBehaviour
{
    public TMP_Text textTimer;
    public TMP_Text textLetters;
    public TMP_Text textDay;
    public TMP_Text timeText;
    public NightTimeLights ntl;

    private float timer = 0.0f;
    private int dayCounter = 1;
    private bool isTimer = true;

    private void Start()
    {
        timer = 450f;
    }

    void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
            DisplayTimer();
        }

        if (timer > 1440.0f)
        {
            dayCounter++;
            timer = 0.0f;
        }

        if (timer > 0.0f && timer < 720.0f)
        {
            textLetters.text = "aM";
        }
        else
        {
            textLetters.text = "pM";
        }

        if (timer < 480.0f || timer > 1200.0f)
        {
            textTimer.color = Color.red;
        }
        else
        {
            textTimer.color = Color.white;
        }

        textDay.text = "day " + dayCounter;

        if (Input.GetKey(KeyCode.Return))
        {
            Time.timeScale = 2.0f;
        }

        if (timer < 480 || timer > 1200)
        {
            timeText.text = "Night Time";
            ntl.SetDayTimeLight();

        }
        else
        {
            timeText.text = "Day Time";
            ntl.SetDayTimeLight();
        }

    }

    void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

}