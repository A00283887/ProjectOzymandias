using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        //this.gameObject.transform.rotation = Quaternion.EulerRotation(new Vector3(0,0,0));
    }
}
