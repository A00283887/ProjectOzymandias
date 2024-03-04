using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displaySchematicCrafting : MonoBehaviour
{
    public GameObject[] others;
    public GameObject Crafting;
    // Start is called before the first frame update
    public void displayCrafting()
    {
        foreach (GameObject gameObject in others)
        {
            if (gameObject.name != Crafting.name)
            {
                gameObject.active = false;
            }
        }

        Crafting.active = true;

    }

    public void hideCrafting()
    {
        Crafting.active = false;
    }
}
