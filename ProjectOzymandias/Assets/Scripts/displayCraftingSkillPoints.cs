using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class displayCraftingSkillPoints : MonoBehaviour
{
    public GameObject text;
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = text.GetComponent<TextMeshProUGUI>().text;
    }
}
