using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDialogue : MonoBehaviour
{
    public Transform Doctor;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Doctor.localScale.x < 0)
        { 
            this.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            this.transform.localScale = new Vector3(1,1,1);
        }
    }
}
