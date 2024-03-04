using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject camera;
    public GameObject camPoint;
    public GameObject light;
    public bool enableScript = true;
    private bool move = false;
    void Start()
    {
        camPoint = GameObject.Find("C7camPoint");
        light = GameObject.Find("C16SpotLight");
    }

    // Update is called once per frame
    void Update()
    {
        if (enableScript)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -10);
            if (move)
            {
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, camPoint.transform.position, 250f * Time.deltaTime);
            }

            if (camera.transform.position == camPoint.transform.position)
            {
                move = false;
            }
        }
    }

    public void Move(string camName)
    {
        Debug.Log(camName + "camPoint");
        Debug.Log(camName + "SpotLight");
        light.GetComponent<Light>().enabled = false;
        camPoint = GameObject.Find(camName + "camPoint");
        move = true;
        light = GameObject.Find(camName + "SpotLight");
        light.GetComponent<Light>().enabled = true;
    }

    public void disableScript()
    {
        enableScript = false;
    }
}
