using MagicPigGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaosController : MonoBehaviour
{
    public HorizontalProgressBar horizontalProgressBar;
    private float progress = 0.50f;

    public RawImage bg;
    public RawImage bubbles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalProgressBar.SetProgress(progress);

        if(progress < 0.50)
        {
            bg.color = new Color(0, 255, 255);
            bubbles.color = Color.white;
        }
        else
        {
            bg.color = new Color(255, 0, 0);
            bubbles.color = Color.black;
        }
    }

    public void addProgress(float p)
    {
        progress += p;
    }

    public void removeProgress(float p)
    {
        progress -= p;
    }

    public float getProgress()
    {
        return progress;
    }
}
