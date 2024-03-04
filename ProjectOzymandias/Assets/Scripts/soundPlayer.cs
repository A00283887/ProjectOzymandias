using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlayer : MonoBehaviour
{
    public AudioClip click;
    public AudioClip zippingSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
    }

    public void ButtonClick2()
    {
        GetComponent<AudioSource>().PlayOneShot(zippingSound);
    }
}
