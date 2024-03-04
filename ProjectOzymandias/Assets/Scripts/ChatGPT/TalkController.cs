using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkController : MonoBehaviour
{
    public GameObject chat1;
    public GameObject chat2;
    public bool GO1Full = false;
    public bool GO2Full = true;
    public string[][] conversations;
    public bool canTalk;

    private Conversation conversation;
    private int conversationIndex = 0;
    public bool cooldown = false;


    private TMP_Text chat1DialogueText;
    private TMP_Text chat2DialogueText;
    private GameObject chat1DialogueBox;
    private GameObject chat2DialogueBox;

    void Start()
    {
        canTalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startConversation(GameObject r)
    {
        if (!cooldown)
        {
            Debug.LogError("WError");
            if (GO1Full == false)
            {
                chat1 = r;
                conversation = chat1.GetComponent<Talk>().GetConversation();
                GO1Full = true;
                GO2Full = false;
            }
            else if (GO2Full == false)
            {
                chat2 = r;
                chat1DialogueBox = chat1.GetComponent<Talk>().getBox();
                chat2DialogueBox = chat2.GetComponent<Talk>().getBox();
                chat1DialogueText = chat1.GetComponent<Talk>().getText().GetComponent<TMP_Text>();
                chat2DialogueText = chat2.GetComponent<Talk>().getText().GetComponent<TMP_Text>();
                StartCoroutine(PlayConversation());
                GO2Full = true;
            }
        }
    }

    private IEnumerator PlayConversation()
    {
        if (conversation == null || conversation.conversations == null || conversation.conversations.Count == 0)
        {
            Debug.LogError("No conversation to play.");
            yield break; // Exit if there's no conversation data.
        }

        // Randomly choose a conversation index.
        int conversationIndex = Random.Range(0, conversation.conversations.Count);
        DoctorAttributes t1 = chat1.transform.GetChild(0).GetComponent<DoctorAttributes>();
        DoctorAttributes t2 = chat2.transform.GetChild(0).GetComponent<DoctorAttributes>();
        var selectedConversation = conversation.conversations[5];

        if (t1.getName() == "James Archer")
        {
            if(t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }            
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Serena Archer")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Dr. Anikin Calderon")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Dr. Isabella Hartley")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Dr. Evan Stone")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Alex Rivera")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }        
        else if (t1.getName() == "Dr. Colm Fitzgerald")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Dr. Ryan Nakamura")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Leo Morgan")
            {
                selectedConversation = conversation.conversations[7];
            }
        }
        else if (t1.getName() == "Leo Morgan")
        {
            if (t2.getName() == "James Archer")
            {
                selectedConversation = conversation.conversations[0];
            }
            else if (t2.getName() == "Serena Archer")
            {
                selectedConversation = conversation.conversations[1];
            }
            else if (t2.getName() == "Dr. Anikin Calderon")
            {
                selectedConversation = conversation.conversations[2];
            }
            else if (t2.getName() == "Dr. Isabella Hartley")
            {
                selectedConversation = conversation.conversations[3];
            }
            else if (t2.getName() == "Dr. Evan Stone")
            {
                selectedConversation = conversation.conversations[4];
            }
            else if (t2.getName() == "Alex Rivera")
            {
                selectedConversation = conversation.conversations[5];
            }
            else if (t2.getName() == "Dr. Colm Fitzgerald")
            {
                selectedConversation = conversation.conversations[6];
            }
            else if (t2.getName() == "Dr. Ryan Nakamura")
            {
                selectedConversation = conversation.conversations[7];
            }
        }


        chat1.GetComponentInParent<DoctorMove>().SetSpeed(0);
        chat2.GetComponentInParent<DoctorMove>().SetSpeed(0);
        chat1.GetComponentInParent<DoctorMove>().enabled = false;
        chat2.GetComponentInParent<DoctorMove>().enabled = false;
        chat1.GetComponentInParent<AILerp>().enabled = false;
        chat2.GetComponentInParent<AILerp>().enabled = false;


        // Flip parents' scale if necessary, before starting the conversation.
        if (chat1 != null && chat2 != null)
        {
            Transform chat1Parent = chat1.transform.parent;
            Transform chat2Parent = chat2.transform.parent;

            // Determine the direction they are facing based on x-axis position.
            bool chat1IsLeftOfChat2 = chat1.transform.position.x < chat2.transform.position.x;

            // Set scale to flip horizontally depending on relative positions.
            float scaleValueChat1 = chat1IsLeftOfChat2 ? -1f : 1f;
            float scaleValueChat2 = chat1IsLeftOfChat2 ? 1f : -1f;

            if (chat1Parent != null) // Check if chat1 has a parent before trying to set its scale.
            {
                Vector3 newScaleChat1 = chat1Parent.localScale;
                newScaleChat1.x = Mathf.Abs(newScaleChat1.x) * scaleValueChat1; // Flip scale while preserving magnitude.
                chat1Parent.localScale = newScaleChat1;
            }

            if (chat2Parent != null) // Check if chat2 has a parent before trying to set its scale.
            {
                Vector3 newScaleChat2 = chat2Parent.localScale;
                newScaleChat2.x = Mathf.Abs(newScaleChat2.x) * scaleValueChat2; // Flip scale while preserving magnitude.
                chat2Parent.localScale = newScaleChat2;
            }
        }

        for (int i = 0; i < selectedConversation.lines.Count; i++)
        {
            TMP_Text currentDialogueText = (i % 2 == 0) ? chat1DialogueText : chat2DialogueText;
            GameObject currentDialogueBox = (i % 2 == 0) ? chat1DialogueBox : chat2DialogueBox;

            // Ensure only the current speaker's dialogue box is visible.
            chat1DialogueBox.transform.localScale = (i % 2 == 0) ? Vector3.one : Vector3.zero;
            chat2DialogueBox.transform.localScale = (i % 2 == 0) ? Vector3.zero : Vector3.one;

            // Clear the text before starting to type out the new line.
            currentDialogueText.text = "";

            // Type out the text letter by letter.
            foreach (char letter in selectedConversation.lines[i])
            {
                currentDialogueText.text += letter;
                yield return new WaitForSeconds(0.1f); // Adjust this value to change the speed of the typing effect.
            }

            // Wait a bit after the full line has been displayed, before moving on to the next line.
            yield return new WaitForSeconds(3f); // Adjust this wait time as necessary.
        }

        // Deactivate both dialogue boxes at the end.
        chat1DialogueBox.transform.localScale = Vector3.zero;
        chat2DialogueBox.transform.localScale = Vector3.zero;

        // Resetting and re-enabling movement for chat1 and chat2.
        chat1.GetComponent<Talk>().startCooldown();
        chat2.GetComponent<Talk>().startCooldown();
        chat1.GetComponentInParent<AILerp>().enabled = true;
        chat2.GetComponentInParent<AILerp>().enabled = true;
        chat1.GetComponentInParent<DoctorMove>().enabled = true;
        chat2.GetComponentInParent<DoctorMove>().enabled = true;
        chat1.GetComponentInParent<DoctorMove>().SetSpeed(1);
        chat2.GetComponentInParent<DoctorMove>().SetSpeed(1);
        cooldown = true;
        StartCoroutine(StartCooldown());
        chat1 = null;
        chat2 = null;
    }


    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(10);
        cooldown = false;
        GO1Full = false;
    }

}