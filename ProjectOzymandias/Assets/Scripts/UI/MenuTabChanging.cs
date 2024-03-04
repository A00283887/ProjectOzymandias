using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTabChanging : MonoBehaviour
{
    public GameObject[] gameObjects;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeMenuToSkills()
    {
        foreach (GameObject g in gameObjects) 
        {
            Debug.Log(g.name);
            if (g.name != "SkillTreeUI")
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }

    public void changeMenuToCrafting()
    {
        foreach (GameObject g in gameObjects)
        {
            if (g.name != "SchematicUI")
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }

    public void changeMenuToUpgrades()
    {
        foreach (GameObject g in gameObjects)
        {
            if (g.name != "UpgradeUI")
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }

    public void changeMenuToOperations()
    {
        foreach (GameObject g in gameObjects)
        {
            if (g.name != "ResearchUI")
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }
}
