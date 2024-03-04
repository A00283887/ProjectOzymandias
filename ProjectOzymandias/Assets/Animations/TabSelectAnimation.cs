using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelectAnimation : MonoBehaviour
{
    private Animator animator;
    public Animator[] animator2;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void enableHover()
    {
        animator.SetBool("Selected", true);
        foreach (Animator a in animator2)
        {
            a.SetBool("Selected", false);
        }
    }

    public void disableHover()
    {

    }
}
