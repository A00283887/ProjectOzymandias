using MagicPigGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionController : MonoBehaviour
{
    public HorizontalProgressBar horizontalProgressBar;
    public RobotController robotController;
    public ClockScript cs;
    public float time = 0f;
    public float progress = 0.0f;
    public float progressMultiplier = 0;
    public GameObject gameOver;
    public GameObject[] doctors;
    public GameObject[] robots;

    public bool beenTo25 = false;
    public bool beenTo35 = false;
    public bool beenTo45 = false;
    public bool beenTo50 = false;
    public bool beenTo60 = false;
    public bool beenTo70 = false;
    public bool beenTo75 = false;

    void Start()
    {
        StartCoroutine(graduallyRemoveSuspicion());
        float doctorCount = 0;
        foreach (GameObject doctor in doctors)
        {
            if (doctor.activeSelf == true)
            {
                doctorCount += 0.1f;
            }
            progressMultiplier = 1 + (doctorCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeMultipiler();
        if(progress < 0)
        {
            progress = 0;
        }
        if (progress > 100)
        {
            progress = 100;
        }

        //Set time to time of day
        time = cs.getTimer();

        //Set Progress bar to progress value
        horizontalProgressBar.SetProgress(progress);

        Punishments();

        if(time > 1040 && time < 1041)
        {
            resetProgress();
        }

    }

    public void addProgress(float p)
    {
        progress += p * progressMultiplier;
    }

    public void removeProgress(float p)
    {
        progress -= p;
    }

    public void resetProgress()
    {
        progress = 0.0f;
    }

    public void timeMultipiler()
    {
        if (time < 480f || time > 1080f)
        {
            progressMultiplier = 0;
        }
        else if (time > 480f && time < 1080f && !(time > 780 && time < 840))
        {
            int doctorCount = 0;
            foreach (GameObject doctor in doctors)
            {
                if (doctor.activeSelf)
                {
                    doctorCount++;
                }
            }
            progressMultiplier = 1 + (doctorCount / 10);
        }

        if (time > 780 && time < 840)
        {
            int doctorCount = 0;
            foreach (GameObject doctor in doctors)
            {
                if (doctor.activeSelf)
                {
                    doctorCount++;
                }
            }
            progressMultiplier = 2 + (doctorCount / 10);
        }
    }

    private void Punishments()
    {
        if (progress < 0.24f)
        {
            beenTo25 = false;
            beenTo35 = false;
            beenTo45 = false;
            beenTo50 = false;
            beenTo60 = false;
            beenTo70 = false;
            beenTo75 = false;
        }

        if ((progress > 0.25f && progress < 0.26f) && !beenTo25)
        {
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().ResetLevel();
            beenTo25 = true;
        }
        else if ((progress > 0.35f && progress < 0.36f) && !beenTo35)
        {
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().ResetLevel();
            beenTo35 = true;

        }
        else if ((progress > 0.45f && progress < 0.46f) && !beenTo45)
        {
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().ResetLevel();
            beenTo45 = true;

        }
        else if ((progress > 0.50f && progress < 0.51f) && !beenTo50)
        {
            Debug.LogWarning("FWEFEF");
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().setHacked(false);
            beenTo50 = true;
            robotController.removeRobot();
        }
        else if ((progress > 0.60f && progress < 0.61f) && !beenTo60)
        {
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().setHacked(false);
            beenTo60 = true;
            robotController.removeRobot();

        }
        else if ((progress > 0.70f && progress < 0.71f) && !beenTo70)
        {
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().setHacked(false);
            beenTo70 = true;
            robotController.removeRobot();

        }
        else if ((progress > 0.75f && progress < 0.75f) && !beenTo75)
        {
            robots[Random.Range(0, robots.Length)].GetComponent<ClickRobot>().setHacked(false);
            beenTo75 = true;
            robotController.removeRobot();
        }
        else if (progress > 0.99f)
        {
            gameOver.SetActive(true);
        }
    }

    IEnumerator graduallyRemoveSuspicion() 
    {
        yield return new WaitForSeconds(30f);
        removeProgress(0.04f);
        StartCoroutine(graduallyRemoveSuspicion());
    }
}
