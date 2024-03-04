using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeFail : MonoBehaviour
{
    private HackController controller;

    void Start()
    {
        controller = GameObject.Find("HackController").GetComponent<HackController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            controller.gameFail();
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            controller.gamePass();
        }
    }
}
