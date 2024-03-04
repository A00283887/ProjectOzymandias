using Pathfinding;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public Conversation conversation;
    private TalkController controller;
    private ClockScript clock;
    public bool lockConversation = false;

    public GameObject DialogueBox;
    public GameObject DialogueText;

    private float time;
    public bool onElevator = false;
    public bool canTalk = false;

    void Start()
    {
        bool canTalk = false;
        controller = GameObject.Find("DoctorCommunication").GetComponent<TalkController>();
        DialogueBox.transform.localScale = new Vector3(0, 0, 0);
        DialogueText.transform.localScale = new Vector3(0,0,0);
        clock = GameObject.Find("TABMenu").GetComponent<ClockScript>();

    }

    private void Update()
    {
        onElevator = this.transform.parent.GetComponent<DoctorMove>().CheckIfOnElevator();
        time = clock.getTimer();
        if ((time > 780f && time < 900f) && !onElevator)
        {
            canTalk = true;
        }
        else
        {
            canTalk = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTalk)
        {
            Debug.LogError("GERwf");
            if (collision.CompareTag("Doctor"))
            {
                controller.startConversation(this.gameObject);
                //lockConversation = true;
            }
        }
    }

    public Conversation GetConversation()
    {
        return conversation;
    }

    public GameObject getBox()
    { return DialogueBox; }

    public GameObject getText() 
    {  
        return DialogueText; 
    }

    public void Cooldown()
    {
        StartCoroutine(startCooldown());
    }

    public IEnumerator startCooldown()
    {
        yield return new WaitForSeconds(30);
        lockConversation= false;
    }
}
