using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public int speed;
    public Transform[] stopPoints;
    public int currentCameraIndex = 5;
    public int targetCameraIndex;
    public int steps;
    public bool moveElevator = false;
    private Animator animator;
    public int floor = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(stopPoints.Length);
        StartCoroutine(MoveElevator(null));
        //transform.position = Vector3.MoveTowards(transform.position, stopPoints[currentCameraIndex].position, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveElevator)
        {
            transform.position = Vector3.MoveTowards(transform.position, getTargetIndex().position, speed * Time.deltaTime);
            if (transform.position == stopPoints[targetCameraIndex].position)
            {
                if (moveElevator)
                {
                    floor = targetCameraIndex;
                    moveElevator = false;
                }
                currentCameraIndex = targetCameraIndex;
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
                Animator door = GameObject.Find("ElevatorDoorLevel" + (currentCameraIndex)).GetComponent<Animator>();
                door.SetBool("Close", false);
                door.SetBool("Open", true);
                StartCoroutine(MoveElevator(door));
            }
        }
    }

    public int getCameraIndex()
    {
        return currentCameraIndex;
    }

    public Transform getTargetIndex()
    {
        if (currentCameraIndex == 0) 
        {
            steps = 1;
        }
        else if (currentCameraIndex == stopPoints.Length - 1)
        {
            steps = -1;
        }

        if (steps > 0) 
        {
            targetCameraIndex = currentCameraIndex + 1;
            return stopPoints[currentCameraIndex + 1].transform;
        }
        else
        {
            targetCameraIndex = currentCameraIndex - 1;
            return stopPoints[currentCameraIndex - 1].transform;
        }
    }

    public IEnumerator MoveElevator(Animator door)
    {
        yield return new WaitForSeconds(5);
        if (door == null)
        {
            Debug.Log("null");
            floor = 99;
            moveElevator = true;
        }
        else
        {
            floor = 99;
            moveElevator = true;
            animator.SetBool("Open", false);
            animator.SetBool("Close", true);
            door.SetBool("Close", true);
            door.SetBool("Open", false);
        }
    }

    public int getFloor()
    {
        return floor;
    }
}
