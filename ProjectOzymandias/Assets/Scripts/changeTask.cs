using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTask : MonoBehaviour
{
    public GameObject robot;

    public void changeTaskButton()
    {
        Debug.Log("Hello");
        if (robot.GetComponent<RobotRoam>().job == 0)
        {
            robot.GetComponent<RobotRoam>().job = 1;
        }

        else if (robot.GetComponent<RobotRoam>().job == 1)
        {
            robot.GetComponent<RobotRoam>().job = 2;
        }


        else if (robot.GetComponent<RobotRoam>().job == 2)
        {
            robot.GetComponent<RobotRoam>().job = 0;
        }

    }
}
