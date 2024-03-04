using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControls : MonoBehaviour
{
    public void SlowTime()
    {
        if (Time.timeScale > 1.0f)
        {
            Time.timeScale -= 1.0f;
        }

        if (Time.timeScale > 0.0f && Time.timeScale <= 1.0f)
        {
            Time.timeScale -= 0.5f;
        }
        Debug.Log(Time.timeScale);
    }

    public void PauseTime()
    {
        if (Time.timeScale != 0.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void SpeedTime()
    {
        if (Time.timeScale < 3.0f)
        {
            Time.timeScale += 1.0f;
        }
    }

    public float getTime() { 
        return Time.timeScale;
    }
}
