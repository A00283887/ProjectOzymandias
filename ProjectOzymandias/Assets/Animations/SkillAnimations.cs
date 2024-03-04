using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAnimations : MonoBehaviour
{
    private Animator animator;
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
        animator.SetBool("Hovering", true);
    }

    public void disableHover()
    {
        animator.SetBool("Hovering", false);
    }
}
