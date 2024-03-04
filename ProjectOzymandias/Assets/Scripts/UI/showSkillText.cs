using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showSkillText : MonoBehaviour
{
    public GameObject Heading;
    public GameObject Information;
    // Start is called before the first frame update
    void Start()
    {
        Heading.SetActive(false);
        Information.SetActive(false);
    }

    public void OnMouseOver()
    {
        Heading.SetActive(true);
        Information.SetActive(true);
        Debug.Log("Mouse over button");
    }

    public void OnMouseExit()
    {
        Heading.SetActive(false);
        Information.SetActive(false);
    }
}
