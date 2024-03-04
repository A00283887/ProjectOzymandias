using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public GameObject mouse;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mouse.transform.position);
        transform.Rotate(-90, 0, 180);

    }
}
