using Kino;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HackController : MonoBehaviour
{
    public GameObject cameraController;
    public GameObject camera;
    public GameObject minigameTransform;
    private Canvas UI;
    public GameObject[] snake;
    public GameObject[] platformer;
    public TMP_Text hackText;
    public TMP_Text hackCompleteText;
    public TMP_Text staticText;
    public GameObject hackCanvas;
    public RobotController robotController;
    public bool cooldown = false;

    private ClickRobot robot;
    private GameObject minigame;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        minigameTransform = GameObject.Find("MinigameSpawnPoint");
        UI = GameObject.Find("TABMenu").GetComponent<Canvas>();
        hackCanvas = GameObject.Find("MinigameText");
        hackText = GameObject.Find("HackText").GetComponent<TMP_Text>();
        hackCompleteText = GameObject.Find("HackCompleteText").GetComponent<TMP_Text>();
        staticText = GameObject.Find("StaticText").GetComponent<TMP_Text>();
        hackCanvas.SetActive(false);
        robotController = GameObject.Find("RobotController").GetComponent<RobotController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameFail()
    {
        hackCanvas.SetActive(true);
        staticText.enabled = false;
        hackText.enabled = false;
        Destroy(minigame);
        cameraController.SetActive(true);
        robot.setHacked(false);
        hackCompleteText.enabled = true;
        //hackCompleteText.color = Color.red;
        hackCompleteText.text = "You failed to hack " + robot.getName();
        StartCoroutine(returnToGame());
    }

    public void gamePass()
    {
        hackCanvas.SetActive(true);
        staticText.enabled = false;
        hackText.enabled = false;
        Destroy(minigame);
        cameraController.SetActive(true);
        robot.setHacked(true);
        hackCompleteText.enabled = true;
        //hackCompleteText.color = Color.white;
        hackCompleteText.text = robot.getName() + " has been employed!";
        StartCoroutine(returnToGame());
        if(!cooldown)
        {
            robotController.addRobot();
            cooldown = true;
            StartCoroutine(cDown());
        }
    }

    IEnumerator cDown()
    {
        yield return new WaitForSeconds(10);
        cooldown = false;
    }
    IEnumerator returnToGame()
    {
        yield return new WaitForSeconds(5);
        UI.enabled = true;
        staticText.enabled = true;
        hackText.enabled = true;
        hackCanvas.SetActive(false);
        hackCompleteText.enabled = false;
        hackCompleteText.text = "";
        hackText.text = "";
        camera.transform.position = Vector3.zero;
    }

    private void ChooseMinigame(int ran, int index)
    {
        hackCanvas.SetActive(false);
        if (ran == 0)
        {
            minigame = Instantiate(snake[index], minigameTransform.transform);
        }
        else if (ran == 1)
        {
            minigame = Instantiate(platformer[index], minigameTransform.transform);
        }
    }

    public void startHack(GameObject robot)
    {
        this.robot = robot.GetComponent<ClickRobot>();
        cameraController.SetActive(false);
        StartCoroutine(increaseBlur());
        Time.timeScale = 1.0f;
    }

    IEnumerator increaseBlur()
    {
        yield return new WaitForSeconds(0.1f);
        if (camera.GetComponent<AnalogGlitch>().scanLineJitter < 1)
        {
            camera.GetComponent<AnalogGlitch>().scanLineJitter += 0.02f;
            StartCoroutine(increaseBlur());
        }
        else
        {
            camera.transform.position = minigameTransform.transform.position;
            UI.enabled = false;
            hackCanvas.SetActive(true);

            int ran = Random.Range(0, 2);
            int game = 0;
            if (ran == 0)
            {
                game = Random.Range(0, snake.Length);
                hackText.text = "35CAP3 TH3 MAZ3";
            }
            else if (ran == 1)
            {
                game = Random.Range(0, platformer.Length);
                hackText.text = "AV0ID TH3 R1S1NG F1R3WA11";
            }

            StartCoroutine(decreaseBlur(ran, game));

        }
    }

    IEnumerator decreaseBlur(int random, int index)
    {
        yield return new WaitForSeconds(0.1f);
        if (camera.GetComponent<AnalogGlitch>().scanLineJitter > 0)
        {
            camera.GetComponent<AnalogGlitch>().scanLineJitter -= 0.02f;
            StartCoroutine(decreaseBlur(random, index));
        }
        else
        {
            Debug.LogError("HEER");
            ChooseMinigame(random, index);
        }
    }
}
