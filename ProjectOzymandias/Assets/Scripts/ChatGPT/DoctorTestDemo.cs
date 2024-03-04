using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DoctorTestDemo : MonoBehaviour
{
    private AILerp aiLerp;
    private AIDestinationSetter aiDestinationSetter;

    public GameObject startPoint;
    public GameObject endPoint;

    private Vector2 previousFrame;
    private Vector2 currentFrame;
    private Animator animator;


    void Start()
    {
        aiLerp = GetComponent<AILerp>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        animator = GetComponent<Animator>();

        aiDestinationSetter.target = startPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {

        previousFrame = currentFrame;
        currentFrame = gameObject.transform.position;

        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
            animator.SetBool("Idle", false);
            animator.SetBool("run", false);
        }
        else if (previousFrame.x == currentFrame.x)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);

        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("run", false);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (aiDestinationSetter.target.gameObject.name == startPoint.name && Vector3.Distance(this.transform.position, aiDestinationSetter.target.transform.position) < 0.5f)
        {
            aiDestinationSetter.target = endPoint.transform;
        }
        else if (aiDestinationSetter.target.gameObject.name == endPoint.name && Vector3.Distance(this.transform.position, aiDestinationSetter.target.transform.position) < 0.5f)
        {
            aiDestinationSetter.target = startPoint.transform;

        }
    }
}
