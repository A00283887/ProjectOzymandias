using UnityEngine;
using System.Collections;

public class showSkillTree : MonoBehaviour
{
    public GameObject SkillTree;
    public Animator skillAnimator;

    private void Start()
    {
        skillAnimator.SetBool("OpenMenu", false);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(skillAnimator.GetBool("OpenMenu"))
            {
                skillAnimator.SetBool("OpenMenu", false);
            }
            else
            {
                skillAnimator.SetBool("OpenMenu", true);
            }
        }
    }
}
