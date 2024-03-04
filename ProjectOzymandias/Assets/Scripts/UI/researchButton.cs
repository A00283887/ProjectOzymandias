using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class researchButton : MonoBehaviour
{
    public GameObject robot1;
    public GameObject robot2;
    public GameObject image1;
    public GameObject image2;
    public GameObject researchimage;
    public GameObject robotCountGO;

    public GameObject text;
    private int activeRobots;

    public int ResearchPoints;

    private int robot1check;
    private int robot2check;
    private int giveskillPoint;

    public int time = 120;
    public int upgradeLvl = 0;

    public void deactivateRobot1()
    {
        if (activeRobots > 2)
        {
            robot1.GetComponent<RobotRoam>().job = 0;
            robot1check = 4;
            image1.active = true;
        }
    }

    public void deactivateRobot2()
    {
        if (activeRobots > 2)
        {
            robot2.GetComponent<RobotRoam>().job = 0;
            robot2check = 4;
            image2.active = true;
        }
    }



    public void Update()
    {
        activeRobots = robotCountGO.GetComponent<RobotController>().currentRobots;
        text.GetComponent<TextMeshProUGUI>().text = ResearchPoints.ToString();

        if (robot1check == 4 && robot2check == 4 && giveskillPoint == 0)
        {
            Invoke("giveResearch", time);
            giveskillPoint = 1;
            robot1check = 0;
            robot2check = 0;
        }
    }

    public void giveResearch()
    {
        if (upgradeLvl == 0)
        {
            ResearchPoints += 1;
        }
        else if (upgradeLvl == 1)
        {
            ResearchPoints += Random.Range(1, 2);
        }
        else if (upgradeLvl == 2)
        {
            ResearchPoints += 2;
        }
        robot1.GetComponent<RobotRoam>().job = 1;
        robot2.GetComponent<RobotRoam>().job = 1;
        showResearchPoint();
        image1.active = false;
        image2.active = false;
        giveskillPoint = 0;
    }

    public void showResearchPoint()
    {
        researchimage.active = true;
        Invoke("removeResearchImage", 5);
    }

    public void removeResearchImage()
    {
        researchimage.active = false;
    }

    public int getResearchPoints()
    {
        return ResearchPoints;
    }

    public void setResearchPoints(int ResearchPoints)
    {
        this.ResearchPoints = ResearchPoints;
    }
}
