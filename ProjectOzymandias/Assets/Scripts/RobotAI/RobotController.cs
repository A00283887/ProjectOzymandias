using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public int maxRobots = 0;
    public int currentRobots = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxRobots(int no)
    {
        maxRobots = no;
    }

    public int getMaxRobots()
    {
        return maxRobots;
    }

    public void addRobot()
    {
        currentRobots++;
    }
    public void removeRobot()
    {
        currentRobots--;
    }

    public int getCurrentRobots()
    {
        return currentRobots;
    }
}
