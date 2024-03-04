using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed;
    public Transform[] cameraPoints;
    public GameObject camera;
    public int currentCameraIndex;
    public int targetCameraIndex;
    private bool moveCamera = false;

    void Start()
    {
        currentCameraIndex = 0;
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, cameraPoints[currentCameraIndex].position, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (moveCamera)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, getTargetIndex().position, speed * Time.deltaTime);
            currentCameraIndex = targetCameraIndex;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentCameraIndex + 1
                < cameraPoints.Length)
            {
                targetCameraIndex = currentCameraIndex + 1;
                moveCamera = true;
            }
            else
            {
                targetCameraIndex = getCameraIndex();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentCameraIndex - 1 >= 0)
            {
                targetCameraIndex = currentCameraIndex - 1;
                moveCamera = true;
            }
            else
            {
                targetCameraIndex = getCameraIndex();
            }
        }
    }

    public int getCameraIndex()
    {
        return currentCameraIndex;
    }

    public Transform getTargetIndex()
    {
        return cameraPoints[targetCameraIndex];
    }
}
