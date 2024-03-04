using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class DoctorMove : MonoBehaviour
{
    public bool goingOnElevator = true;
    private bool onElevator = false;
    public int job = -1;
    public int assignedJob = 1;
    public int subJob = 0;
    private int speed = 1;
    private float timer;
    public int randomfloor = 0;
    private GameObject doctor;
    public GameObject[] floor0;
    public GameObject[] floor1;
    public GameObject[] floor2;
    public GameObject target;
    public int floor;
    private bool lockFloor = false;

    private bool lockElevator = false;

    private Elevator elevator;
    private Animator animator;

    //private RobotChangeFloor rcf;
    private AIDestinationSetter destinationSetter;
    private AILerp ai;

    private ClockScript time;

    private Vector2 previousFrame;
    private Vector2 currentFrame;
    public int elevatorFloor;

    private bool cooldown = false;

    private void Start()
    {
        ai = GetComponent<AILerp>();
        animator = GetComponent<Animator>();
        floor = 4;
        doctor = this.gameObject;
        destinationSetter = this.GetComponent<AIDestinationSetter>();
        elevator = GameObject.Find("elevator").GetComponent<Elevator>();
        target = GameObject.Find("SpawnPointLevel4");
        destinationSetter.target = target.transform;
        time = GameObject.Find("TABMenu").GetComponent<ClockScript>();
    }

    private void Update()
    {
        ai.speed = speed;

        /*if (ai.speed > 0 && ai.speed <= 2.5f) 
        {
            animator.SetBool("Idle", false);
            animator.SetBool("run", false);
        }
        else if (ai.speed > 2.5f && ai.speed <= 5)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("run", true);
        }
        else if (ai.speed <= 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
        }*/

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

        elevatorFloor = elevator.getFloor();
        timer = time.getTimer();

        if (timer > 480 && timer < 481)
        {
            goingOnElevator = true;
            job = assignedJob;
            lockElevator = true;
        }

        if (timer > 780 && timer < 840)
        {
            job = 4;
        }

        if (timer > 860 && timer <960)
        {
            destinationSetter.enabled = true;
            int targetFloor = 10;
            if (assignedJob == 0)
            {
                targetFloor = 3;
            }
            else if (assignedJob == 1)
            {
                targetFloor = 2;
            }
            else if (assignedJob == 2)
            {
                targetFloor = 1;
            }
            else if (assignedJob == 3)
            {
                targetFloor = 0;
            }

            if (floor == targetFloor)
            {
                job = assignedJob;
            }
        }
        else
        {
            cooldown=false;
        }

        if (timer > 1080 && timer < 1081)
        {
            job = 6;
        }

        if (job == -1)
        {
            previousFrame = currentFrame;
            currentFrame = gameObject.transform.position;

            if (previousFrame.x < currentFrame.x)
            {
                gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
            }

        }

        if (job == 0)
        {
            topFloor();
        }
        else if (job == 1)
        {
            floor2Route();
        }
        else if (job == 2)
        {
            floor1Route();
        }
        else if (job == 3)
        {
            floor0Route();
        }
        else if (job == 4)
        {
            doctorRoam();
        }
        else if (job == 6)
        {
            if (lockElevator) 
            {
                goingOnElevator = true;
                lockElevator = false;
            }
            leaveFacility();
        }

    }

    private void topFloor()
    {

        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (target.name == "SpawnPointLevel4" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            Debug.Log("GIEFWA");
            target = GameObject.Find("ElevatorPointLevel4");
            destinationSetter.target = target.transform;
        }
        if (goingOnElevator && (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0"))
        {

            if (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0")
            {
                if (elevator.getFloor() == floor && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = true;
                    animator.SetBool("run", true);
                    animator.SetBool("Idle", false);
                    target = GameObject.Find("ElevatorCheckpoint");
                    destinationSetter.target = target.transform;
                    speed = 3;
                    onElevator = true;
                }
            }
            else if (!(elevator.getFloor() == floor) && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                destinationSetter.enabled = false;
                animator.SetBool("Idle", true);
            }
        }

        if (target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
            goingOnElevator = false;
        }


        if (elevator.getFloor() == 3 && target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            floor = 3;
            animator.SetBool("run", false);
            animator.SetBool("Idle", false);
            destinationSetter.enabled = true;
        }

        if (floor == 3)
        {
            if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel3");
                destinationSetter.target = target.transform;
                onElevator = false;
            }
            else if (target.name == "ElevatorPointLevel3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point1Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point1Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob != 1 && subJob != 3 && subJob != 2))
            {
                target = GameObject.Find("Point2Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f &&(subJob != 3 && subJob != 0 && subJob != 2))
            {
                target = GameObject.Find("Point3Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point3Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob != 1 && subJob != 0 && subJob != 3))
            {
                target = GameObject.Find("Point4Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point4Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob != 1 && subJob != 0 && subJob != 2))
            {
                target = GameObject.Find("Point5Level3");
                destinationSetter.target = target.transform;
            }
        }
    }

    private void floor2Route()
    {

        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (target.name == "SpawnPointLevel4" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            target = GameObject.Find("ElevatorPointLevel4");
            destinationSetter.target = target.transform;
        }
        if (goingOnElevator && (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0"))
        {
            if (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0")
            {
                if (elevator.getFloor() == floor && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = true;
                    animator.SetBool("run", true);
                    animator.SetBool("Idle", false);
                    target = GameObject.Find("ElevatorCheckpoint");
                    destinationSetter.target = target.transform;
                    speed = 3;
                    onElevator = true;

                }
                else if (!(elevator.getFloor() == floor) && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = false;
                    animator.SetBool("Idle", true);
                }
            }
        }
        if (target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
            goingOnElevator = false;
        }

        if (elevator.getFloor() == 2 && target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            floor = 2;
            animator.SetBool("run", false);
            animator.SetBool("Idle", false);
            destinationSetter.enabled = true;
        }

        if (floor == 2)
        {
            if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel2");
                destinationSetter.target = target.transform;
                onElevator = false;
            }
            else if (target.name == "ElevatorPointLevel2" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 1 || subJob == 2 || subJob == 0))
            {
                if (subJob == 0)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point1Level2");
                destinationSetter.target = target.transform;
                goingOnElevator = true;
            }
            else if (target.name == "Point1Level2" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 1 || subJob == 2))
            {
                if (subJob == 1)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point2Level2");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level2" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 2))
            {
                if (subJob == 2)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point3Level2");
                destinationSetter.target = target.transform;
            }
        }
    }

    private void floor1Route()
    {

        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (target.name == "SpawnPointLevel4" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            Debug.Log("GIEFWA");
            target = GameObject.Find("ElevatorPointLevel4");
            destinationSetter.target = target.transform;

        }

        if (goingOnElevator && (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0"))
        {
            if (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0")
            {
                if (elevator.getFloor() == floor && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = true;
                    animator.SetBool("run", true);
                    animator.SetBool("Idle", false);
                    target = GameObject.Find("ElevatorCheckpoint");
                    destinationSetter.target = target.transform;
                    speed = 3;
                    onElevator = true;
                }
                else if (!(elevator.getFloor() == floor) && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = false;
                    animator.SetBool("Idle", true);
                }
            }
        }

        if (target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
            goingOnElevator = false;
        }

        if (elevator.getFloor() == 1 && target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            floor = 1;
            animator.SetBool("run", false);
            animator.SetBool("Idle", false);
            destinationSetter.enabled = true;
        }

        if (floor == 1)
        {
            if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel1");
                destinationSetter.target = target.transform;
                onElevator = false;
            }
            else if (target.name == "ElevatorPointLevel1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 1 || subJob == 2 || subJob == 0))
            {
                if (subJob == 0)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point1Level1");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point1Level1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 1 || subJob == 2))
            {
                if (subJob == 1)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point2Level1");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 2))
            {
                if (subJob == 2)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point3Level1");
                destinationSetter.target = target.transform;
            }
        }
    }

    private void floor0Route()
    {
        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (target.name == "SpawnPointLevel4" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            target = GameObject.Find("ElevatorPointLevel4");
            destinationSetter.target = target.transform;
        }


        if (goingOnElevator && (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0"))
        {
            if (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0")
            {
                if (elevator.getFloor() == floor && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = true;
                    animator.SetBool("run", true);
                    animator.SetBool("Idle", false);
                    target = GameObject.Find("ElevatorCheckpoint");
                    destinationSetter.target = target.transform;
                    speed = 3;
                    onElevator = true;
                }
                else if (!(elevator.getFloor() == floor) && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = false;
                    animator.SetBool("Idle", true);
                }
            }
        }

        if (target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
            goingOnElevator = false;
        }

        if (elevator.getFloor() == 0 && target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            floor = 0;
            animator.SetBool("run", false);
            animator.SetBool("Idle", false);
            destinationSetter.enabled = true;
        }

        if (floor == 0)
        {
            if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel0");
                destinationSetter.target = target.transform;
                onElevator = false;
            }
            else if (target.name == "ElevatorPointLevel0" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 1 || subJob == 2 || subJob == 0))
            {
                if (subJob == 0)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point1Level0");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point1Level0" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 1 || subJob == 2))
            {
                if(subJob == 1) 
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point2Level0");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level0" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && (subJob == 2))
            {
                if (subJob == 2)
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("run", false);
                }
                target = GameObject.Find("Point3Level0");
                destinationSetter.target = target.transform;
            }
        }
    }

    private void doctorRoam()
    {

        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (goingOnElevator && (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0"))
        {
            if (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0")
            {
                if (!lockFloor)
                {
                    randomfloor = Random.Range(0, 3);
                    lockFloor = true;
                }

                if (elevator.getFloor() == floor && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = true;
                    animator.SetBool("run", true);
                    animator.SetBool("Idle", false);
                    target = GameObject.Find("ElevatorCheckpoint");
                    destinationSetter.target = target.transform;
                    speed = 3;
                    onElevator = true;
                }
                else if (!(elevator.getFloor() == floor) && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = false;
                    animator.SetBool("Idle", true);
                }
            }
        }
        else if (!goingOnElevator || (Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f) && (target.name != "ElevatorPointLevel4" && target.name != "ElevatorPointLevel3" && target.name != "ElevatorPointLevel3" && target.name != "ElevatorPointLevel1" && target.name != "ElevatorPointLevel0" && target.name != "ElevatorCheckpoint"))
        {
            goingOnElevator = true;
            lockFloor = false;
            if (floor == 0)
            {
                int nextTarget = Random.Range(0, floor0.Length);
                target = floor0[nextTarget];
                destinationSetter.target = target.transform;
            }
            else if (floor == 1)
            {

                int nextTarget = Random.Range(0, floor1.Length);
                target = floor1[nextTarget];
                destinationSetter.target = target.transform;

            }
            else if (floor == 2)
            {
                int nextTarget = Random.Range(0, floor2.Length);
                target = floor2[nextTarget];
                destinationSetter.target = target.transform;

            }
            else if (floor == 3)
            {
                int nextTarget = Random.Range(0, floor2.Length);
                target = floor2[nextTarget];
                destinationSetter.target = target.transform;
            }

        }


        if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && randomfloor == 0)
        {
            if (elevatorFloor == randomfloor)
            {
                speed = 1;
                floor = 0;
                target = GameObject.Find("ElevatorPointLevel0");
                destinationSetter.target = target.transform;
                goingOnElevator = false;
                animator.SetBool("run", false);
                animator.SetBool("Idle", false);
                onElevator = false;
            }
            else
            {
                animator.SetBool("Idle", true);
                animator.SetBool("run", false);
                speed = 3;
            }
        }
        else if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && randomfloor == 1)
        {
            if (elevatorFloor == randomfloor)
            {
                speed = 1;
                floor = 1;
                target = GameObject.Find("ElevatorPointLevel1");
                destinationSetter.target = target.transform;
                goingOnElevator = false;
                animator.SetBool("run", false);
                animator.SetBool("Idle", false);
                onElevator = false;
            }
            else
            {
                animator.SetBool("Idle", true);
                animator.SetBool("run", false);
                speed = 3;
            }
        }
        else if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && randomfloor == 2)
        {
            if (elevatorFloor == randomfloor)
            {
                speed = 1;
                floor = 2;
                target = GameObject.Find("ElevatorPointLevel2");
                destinationSetter.target = target.transform;
                goingOnElevator = false;
                animator.SetBool("run", false);
                animator.SetBool("Idle", false);
                onElevator = false;
            }
            else
            {
                animator.SetBool("Idle", true);
                animator.SetBool("run", false);
                speed = 3;
            }
        }
        else if (target == GameObject.Find("ElevatorCheckpoint") && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f && randomfloor == 3)
        {
            if (elevatorFloor == randomfloor)
            {
                speed = 1;
                floor = 3;
                target = GameObject.Find("ElevatorPointLevel3");
                destinationSetter.target = target.transform;
                goingOnElevator = false;
                animator.SetBool("run", false);
                animator.SetBool("Idle", false);
                onElevator = false;
            }
            else
            {
                animator.SetBool("Idle", true);
                animator.SetBool("run", false);
                speed = 3;
            }
        }
    }

    private void leaveFacility()
    {

        if (previousFrame.x < currentFrame.x)
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f);
        }

        if (goingOnElevator && (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0"))
        {
            if (target.name == "ElevatorPointLevel4" || target.name == "ElevatorPointLevel3" || target.name == "ElevatorPointLevel2" || target.name == "ElevatorPointLevel1" || target.name == "ElevatorPointLevel0")
            {
                if (elevator.getFloor() == floor && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = true;
                    animator.SetBool("run", true);
                    animator.SetBool("Idle", false);
                    target = GameObject.Find("ElevatorCheckpoint");
                    destinationSetter.target = target.transform;
                    speed = 3;
                    onElevator = true;
                }
                else if (!(elevator.getFloor() == floor) && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
                {
                    destinationSetter.enabled = false;
                    animator.SetBool("Idle", true);
                }
            }
        }

        if (target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("run", false);
            goingOnElevator = false;
        }

        if (elevator.getFloor() == 4 && target.name == "ElevatorCheckpoint" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            floor = 4;
            animator.SetBool("run", false);
            animator.SetBool("Idle", false);
            destinationSetter.enabled = true;
            target = GameObject.Find("ElevatorPointLevel4");
            destinationSetter.target = target.transform;
            onElevator = false;

        }

        if (target.name == "ElevatorPointLevel4" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            target = GameObject.Find("SpawnPointLevel4");
            destinationSetter.target = target.transform;
        }

        if (target.name == "SpawnPointLevel4" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
        {
            job = -1;
        }


        if (floor == 0)
        {
            if (target.name == "Point1Level0" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel0");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level0" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point1Level0");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point3Level0" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point2Level0");
                destinationSetter.target = target.transform;
            }
        }
        else if (floor == 1)
        {
            if (target.name == "Point1Level1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel1");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point1Level1");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point3Level1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point2Level1");
                destinationSetter.target = target.transform;
            }
        }
        else if (floor == 2)
        {
            if (target.name == "Point1Level2" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel2");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level2" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point1Level2");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point3Level2" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point2Level2");
                destinationSetter.target = target.transform;
            }
        }
        else if (floor == 3)
        {
            if (target.name == "Point1Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("ElevatorPointLevel3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point2Level1" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point1Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point3Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point2Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point4Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point3Level3");
                destinationSetter.target = target.transform;
            }
            else if (target.name == "Point3Level3" && Vector3.Distance(doctor.transform.position, target.transform.position) < 0.5f)
            {
                target = GameObject.Find("Point4Level3");
                destinationSetter.target = target.transform;
            }
        }
    }

    public bool CheckIfOnElevator()
    {
        return onElevator;
    }

    public void SetSpeed(int s)
    {
        speed = s;
    }
}