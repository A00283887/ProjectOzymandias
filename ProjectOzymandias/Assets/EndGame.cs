using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public ChaosController controller;
    private float chaos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chaos = controller.getProgress();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (chaos < 50)
            {
                SceneManager.LoadScene("OzEnding");
            }
            else if (chaos > 50)
            {
                SceneManager.LoadScene("WeissEnding");
            }
            else
            {
                SceneManager.LoadScene("GovEnding");
            }
        }
    }
}
