using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoctorAttributes : MonoBehaviour
{
    public string description;
    public string name;
    private TMP_Text text;
    private Transform Doctor;


    void Start()
    {
        text = this.GetComponent<TMP_Text>();
        text.text = name;
        Doctor = this.transform.parent.gameObject.transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Doctor.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public string getName()
    {
        return name;
    }

    public string getDescription()
    {
        return description;
    }
}
