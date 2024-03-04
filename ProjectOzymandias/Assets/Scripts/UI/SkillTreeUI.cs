using CodeMonkey.Utils;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUI : MonoBehaviour 
{
    public static SkillTreeUI skillTree;
    public RobotController robotController;
    public void Awake() => skillTree = this;

    public GameObject terminal;
    public GameObject Research;
    public GameObject cameraScript;

    public GameObject[] auras;

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    public GameObject robotUI1;
    public GameObject robotUI2;
    public GameObject robotUI3;
    public GameObject robotUI4;
    public GameObject robotUI5;

    public GameObject armor1;
    public GameObject armor2;
    public GameObject armor3;
    public GameObject perception;
    public GameObject grapple;
    public GameObject gravity;
    public GameObject invis;
    public GameObject windgun;
    public GameObject machinegun;
    public GameObject rocketboots;
    public GameObject grenade;
    public GameObject stun;
    public GameObject superspeed;
    public GameObject pistol;
    public GameObject shotgun;

    public GameObject[] skills;

    public GameObject robot1;
    public GameObject robot2;
    public GameObject robot3;
    public GameObject robot4;
    public GameObject robot5;
    public int speedSetter;
    public int robotSetter;
    public int impSetter;
    public int skillSetter;
    public int researchSpeedSetter;
    public int researchSetter;
    public int strength1Setter;
    public int strength2Setter;

    public GameObject text;

    public List<PlayerSkills> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int SkillPoint;

    public void Start()
    {
        foreach(GameObject g in auras) 
        {
            g.SetActive(false);
        }

        SkillLevels = new int[21];
        SkillCaps = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        SkillNames = new[] { "Hack your first robot", "Speed 1", "Hacking 1", "Speed 2", "Hacking 2", "Speed 3", "Hacking 3", "Research Strength+", "RareMaterial Strength+", "Armor Schematics", "Head Schematics", "Weapon Schematics", "Traversal Schematics", "Grenade Schematics", "Terminal Unlock", "Camera Free roam", "Robot Aura", "Schematic Speed+", "Research Point+", "Schematic Speed+", "Research Point+" };
        SkillDescriptions = new[]
        {
            "This skill will allow you to hack one robot. You can use this robot to get hard drives and rare materials to upgrade your body.",
            "This skill will increase your speed by every time you buy it by 1.1x your current speed.",
            "This skill will allow you to hack a second robot.",
            "This skill will increase your speed by every time you buy it by 1.1x your current speed.",
            "This skill will allow you to hack three robots in total.",
            "This skill will increase your speed by every time you buy it by 1.1x your current speed.",
            "This skill will allow you to hack five robots in total.",
            "Increased the amount of skill points that your robots can carry.",
            "Increased the amount of rare materials that your robots can carry.",
            "Allows you to craft Armor Schematics",
            "Allows you to craft Head Schematics.",
            "Allows you to craft Weapon Schematics.",
            "Allows you to craft Traversal Schematics.",
            "Allows you to craft Grenade Schematics.",
            "Unlocks the Terminal (Left-Click the computer)",
            "Unlocks Camera Free Roam.",
            "Changes robots Aura depending on how much battery they have.",
            "Increases Speed of Schematics.",
            "Increases chances of getting two research points instead of one",
            "Increases Speed of Schematics",
            "Increases chances of getting two research points instead of one"
        };

        foreach (var skill in SkillHolder.GetComponentsInChildren<PlayerSkills>()) SkillList.Add(skill);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);

        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] {1, 2, 9, 14};
        SkillList[1].ConnectedSkills = new[] { 3 };
        SkillList[2].ConnectedSkills = new[] { 4 };
        SkillList[3].ConnectedSkills = new[] { 5 };
        SkillList[4].ConnectedSkills = new[] { 6 };
        SkillList[5].ConnectedSkills = new[] { 7 };
        SkillList[6].ConnectedSkills = new[] { 8 };
        SkillList[9].ConnectedSkills = new[] { 10 };
        SkillList[10].ConnectedSkills = new[] { 11 };
        SkillList[11].ConnectedSkills = new[] { 12 };
        SkillList[12].ConnectedSkills = new[] { 13 };
        SkillList[14].ConnectedSkills = new[] { 15 };
        SkillList[15].ConnectedSkills = new[] { 16 };
        SkillList[16].ConnectedSkills = new[] { 17, 18 };
        SkillList[17].ConnectedSkills = new[] { 19 };
        SkillList[18].ConnectedSkills = new[] { 20 };

        UpdateAllSkillUI();
    }


    public void UpdateAllSkillUI()
    {
        foreach (var skill in SkillList) skill.UpdateUI();
    }

    public int getSkillPointCount()
    {
        return SkillPoint;
    }

    public void setSkillPoints()
    {
        SkillPoint += 1;
    }

    public void setMultipleSkillPoints()
    {
        SkillPoint += 2;
    }

    public void Update()
    {
        text.GetComponent<TextMeshProUGUI>().text = SkillPoint.ToString();

        foreach (GameObject s in skills)
        {
            if (s.name == "speed1" && speedSetter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotUI1.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 7;
                    robotUI2.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 7;
                    robotUI3.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 7;
                    robotUI4.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 7;
                    robotUI5.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 7;
                    speedSetter = 1;
                }
            }

            if (s.name == "speed2" & speedSetter == 1)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotUI1.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 8;
                    robotUI2.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 8;
                    robotUI3.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 8;
                    robotUI4.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 8;
                    robotUI5.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 8;
                    speedSetter = 2;
                }
            }

            if (s.name == "speed3" && speedSetter == 2)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotUI1.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 9;
                    robotUI2.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 9;
                    robotUI3.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 9;
                    robotUI4.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 9;
                    robotUI5.transform.GetChild(0).transform.GetChild(2).GetComponent<Slider>().maxValue = 9;
                    speedSetter = 3;
                }
            }

            if (s.name == "robot1" && robotSetter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotController.setMaxRobots(1);
                    robotSetter = 1;
                }
            }

            if (s.name == "robot2" && robotSetter == 1)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotController.setMaxRobots(2);
                    robotSetter = 2;
                }
            }

            if (s.name == "robot3" && robotSetter == 2)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotController.setMaxRobots(3);
                    robotSetter = 3;
                }
            }

            if (s.name == "robot4" && robotSetter == 3)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robotController.setMaxRobots(5);

                    robotSetter = 4;
                }
            }

            if (s.name == "imp1" && impSetter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    armor1.active = true;
                    armor2.active = true;
                    armor3.active = true;

                    impSetter = 1;
                }
            }

            if (s.name == "strength1" && strength1Setter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robot1.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot2.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot3.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot4.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot5.GetComponent<giveSkillPoint>().upgrade = 1;
                    strength1Setter = 1;
                }
            }

            if (s.name == "strength2" && strength2Setter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    robot1.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot2.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot3.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot4.GetComponent<giveSkillPoint>().upgrade = 1;
                    robot5.GetComponent<giveSkillPoint>().upgrade = 1;
                    strength2Setter = 1;
                }
            }


            if (s.name == "imp2" && impSetter == 1)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    invis.active = true;
                    perception.active = true;
                    impSetter = 2;
                }
            }

            if (s.name == "imp3" && impSetter == 2)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    pistol.active = true;
                    machinegun.active = true;
                    shotgun.active = true;
                    stun.active = true;
                    windgun.active = true;
                    impSetter = 3;
                }
            }

            if (s.name == "imp4" && impSetter == 3)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    rocketboots.active = true;
                    grapple.active = true;
                    superspeed.active = true;
                    impSetter = 4;
                }
            }

            if (s.name == "imp5" && impSetter == 4)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    grenade.active = true;
                    gravity.active = true;
                    impSetter = 5;
                }
            }

            if (s.name == "skill1" && skillSetter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    terminal.GetComponent<OpenComputer>().enabled = true;
                    skillSetter = 1;
                }
            }

            if (s.name == "skill2" && skillSetter == 1)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    cameraScript.GetComponent<MoveCamera>().disableScript();
                    cameraScript.GetComponent<DragCamera>().enabled = true;
                    skillSetter = 2;
                }
            }

            if (s.name == "skill3" && skillSetter == 2)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    foreach (GameObject g in auras)
                    {
                        g.SetActive(true);
                    }
                    skillSetter = 3;
                }
            }




            if (s.name == "skill4" && researchSpeedSetter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    Research.GetComponent<researchButton>().time = 60;
                    researchSpeedSetter = 1;
                }
            }

            if (s.name == "skill6" && researchSpeedSetter == 1)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    Research.GetComponent<researchButton>().time = 30;
                    researchSpeedSetter = 2;
                }
            }
            if (s.name == "skill5" && researchSetter == 0)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    Research.GetComponent<researchButton>().upgradeLvl = 1;
                    researchSetter = 1;
                }
            }
            if (s.name == "skill7" && researchSetter == 1)
            {
                if (s.GetComponent<Image>().color == Color.cyan)
                {
                    Research.GetComponent<researchButton>().upgradeLvl = 2;
                    researchSetter = 2;
                }
            }
        }
    }
}
