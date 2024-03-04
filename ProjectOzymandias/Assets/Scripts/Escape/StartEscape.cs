using Kino;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartEscape : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject vCam;
    public GameObject camera;
    public GameObject escapeCanvas;
    private TMP_Text instructionText;
    public PlayerController pc;
    public Transform demo;
    public GameObject[] enemies;
    void Start()
    {
        instructionText = escapeCanvas.transform.GetChild(5).gameObject.GetComponent<TMP_Text>();
        instructionText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEscaping()
    {
        foreach (GameObject obj in objects) 
        { 
            obj.SetActive(false);
        }
        instructionText.enabled = true;
        instructionText.text = "35CAP3 TH3 FAC1L1TY";
        Time.timeScale = 1.0f;
        pc.enabled = true;
        StartCoroutine(increaseBlur());

        foreach (GameObject obj in enemies) 
        {
            obj.SetActive(true);
        }
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
            escapeCanvas.SetActive(true);
            vCam.SetActive(true);
            StartCoroutine(decreaseBlur());
        }
    }

    IEnumerator decreaseBlur()
    {
        yield return new WaitForSeconds(0.1f);
        if (camera.GetComponent<AnalogGlitch>().scanLineJitter > 0)
        {
            camera.GetComponent<AnalogGlitch>().scanLineJitter -= 0.02f;
            StartCoroutine(decreaseBlur());
        }
        else
        {
            showUI();
            demo.localScale = Vector3.one;
            StartCoroutine(minimizeTab());
        }
    }

    private void showUI()
    {
        instructionText.enabled = false;
        escapeCanvas.transform.GetChild(0).gameObject.SetActive(true);
        escapeCanvas.transform.GetChild(1).gameObject.SetActive(true);
        escapeCanvas.transform.GetChild(2).gameObject.SetActive(true);
        escapeCanvas.transform.GetChild(3).gameObject.SetActive(true);
        escapeCanvas.transform.GetChild(4).gameObject.SetActive(true);
    }

    IEnumerator minimizeTab()
    {
        yield return new WaitForSeconds(7f);
        demo.localScale = Vector3.zero;
    }
}
