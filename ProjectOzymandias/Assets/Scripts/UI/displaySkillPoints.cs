using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displaySkillPoints : MonoBehaviour
{
    public string researchPoints;
    public GameObject research;
   

    private void Start()
    {
    }
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = research.GetComponent<researchButton>().ResearchPoints.ToString();
    }
}
