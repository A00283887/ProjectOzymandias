using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSpriteDoctor : MonoBehaviour
{
    private AILerp ai;
    private Animator animator;
    private Vector2 previousFrame;
    private Vector2 currentFrame;

    void Start()
    {
        ai = GetComponent<AILerp>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        previousFrame = currentFrame;
        currentFrame = gameObject.transform.position;

        if (previousFrame.x == currentFrame.x)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("run", false);
        }
    }
}
