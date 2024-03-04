using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBackgroundAnimations : MonoBehaviour
{

    private Animator animator;
    private SkillTreeUI stu;
    void Start()
    {
        animator = GetComponent<Animator>();
        stu = GameObject.Find("SkillTree").GetComponent<SkillTreeUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tier1Unlock()
    {
        if(stu.getSkillPointCount() > 0)
        {
            animator.SetBool("Tier1Unlock", true);
        }
    }

    public void Tier2Unlock()
    {
        if (stu.getSkillPointCount() > 0)
        {
            animator.SetBool("Tier2Unlock", true);
        }
    }

    public void Tier3Unlock()
    {
        if (stu.getSkillPointCount() > 0)
        {
            animator.SetBool("Tier3Unlock", true);
        }
    }
    public void Tier4Unlock()
    {
        if (stu.getSkillPointCount() > 0)
        {
            animator.SetBool("Tier4Unlock", true);
        }
    }
    public void Tier5Unlock()
    {
        if (stu.getSkillPointCount() > 0)
        {
            animator.SetBool("Tier5Unlock", true);
        }
    }
}
