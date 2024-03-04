using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class giveSkillPoint : MonoBehaviour
{
    public GameObject Robot;
    private GameObject computer;
    private GameObject serverRoom;
    private SkillTreeUI stu;
    public bool hasSkillPoint = false;
    public int upgrade = 0;

    private void Start()
    {
        computer = GameObject.Find("ComputerFloor0");
        serverRoom = GameObject.Find("Floor1ServerRoom");
        stu = GameObject.Find("SkillTree").GetComponent<SkillTreeUI>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == computer)
        {
            if (hasSkillPoint == true)
            {
                if (upgrade == 0)
                {
                    stu.setSkillPoints();
                    hasSkillPoint = false;
                }

                if (upgrade == 1)
                {
                    stu.setMultipleSkillPoints();
                    hasSkillPoint = false;
                }
            }
        }

        if (other.gameObject.name == serverRoom.name)
        {
            hasSkillPoint = true;
        }
    }
}
