using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFail : MonoBehaviour
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
        if(collision.gameObject.CompareTag("Enemy"))
        {
            controller.gameFail();
        }

        if(collision.gameObject.CompareTag("Respawn"))
        {
            controller.gamePass();
        }
    }
}
