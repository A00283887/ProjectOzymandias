using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotChangeFloor : MonoBehaviour
{
    public GameObject[] floors;
    int randomFloor = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToRandomFloor(GameObject robot)
    {
        randomFloor = Random.Range(0, 3);
        robot.GetComponent<AILerp>().enabled = false;
        robot.transform.position = floors[randomFloor].transform.position;
        robot.GetComponent<AILerp>().enabled = true;
        Debug.Log("TP" + randomFloor);
    }

    public int getFloor()
    {
        return randomFloor;
    }
    public void changeToFloor(int floor, GameObject robot)
    {
        robot.GetComponent<AILerp>().enabled = false;
        robot.transform.position = floors[floor].transform.position;
        robot.GetComponent<AILerp>().enabled = true;
        randomFloor = floor;
    }
}
