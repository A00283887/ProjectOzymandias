using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    private GameObject camera;
    private bool goToComputer;
    public GameObject computerUI;

    public Sprite off;
    public Sprite on;
    
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        computerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (goToComputer)
        {
            computerUI.SetActive(true);
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, new Vector3(this.gameObject.transform.position.x + 1.5f, this.gameObject.transform.position.y, this.transform.position.z), .5f);
        }

        if (Input.GetKey(KeyCode.Escape) && goToComputer == true)
        {
            goToComputer = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = on;
            computerUI.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        goToComputer = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = on;
    }
}
