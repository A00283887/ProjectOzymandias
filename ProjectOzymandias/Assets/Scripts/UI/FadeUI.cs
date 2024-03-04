using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public TMP_Text time;
    public TMP_Text timer;
    public TMP_Text ampm;
    public TMP_Text dayCounter;
    void Start()
    {
        time.enabled = false;
        timer.enabled = false;
        ampm.enabled = false;
        dayCounter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerText()
    {
        time.enabled = true;
        timer.enabled = true;
        ampm.enabled = true;
        dayCounter.enabled = true;
        Time.timeScale = 1.0f;
    }

    public void disableTime() 
    {
        time.enabled = false;
        timer.enabled = false;
        ampm.enabled = false;
        dayCounter.enabled = false;
    }
}
