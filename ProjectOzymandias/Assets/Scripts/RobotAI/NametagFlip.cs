using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NametagFlip : MonoBehaviour
{
    public Transform Robot;
    void Start()
    {
        Robot = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Robot.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
