using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayRareMaterials : MonoBehaviour
{
    public int rareMaterials;

    public GameObject[] text;

    void Update()
    {
        foreach (GameObject g in text)
        {
            g.GetComponent<TextMeshProUGUI>().text = rareMaterials.ToString();
        }
    }

    public void setRareMaterials()
    {
        rareMaterials += 1;
        foreach (GameObject g in text)
        {
            g.GetComponent<TextMeshProUGUI>().text = rareMaterials.ToString();
        }
    }

    public int getRareMaterials()
    {
        return rareMaterials;
    }

    public void giveMultipleRareMaterials()
    {
        rareMaterials += 2;
        foreach (GameObject g in text)
        {
            g.GetComponent<TextMeshProUGUI>().text = rareMaterials.ToString();
        }
    }

    public void removeRareMaterial()
    {
        rareMaterials -= 1;
        foreach (GameObject g in text)
        {
            g.GetComponent<TextMeshProUGUI>().text = rareMaterials.ToString();
        }
    }
}
