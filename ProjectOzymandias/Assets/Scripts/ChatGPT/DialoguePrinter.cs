using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialoguePrinter : MonoBehaviour
{
    public string[] dialogue;
    public string[] otherDialogue;
    public GameObject square;
    public DialogueController dialogueController;
    private DialogueController otherDialogueController;
    private TMP_Text text;
    private TMP_Text otherText;
    int dialogueLength;
    int otherDialogueLength;
    int index = 1;
    int otherIndex = 1;

    public GameObject thisDoctor;
    public GameObject otherDoctor;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        square.SetActive(false);
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void addToDialogue(int index, string s)
    {
        dialogue[index] = s;
    }

    public void StartConversation(int a, DialogueController dc, TMP_Text texts)
    {
        otherText = texts;
        otherDialogueController = dc;
        otherDialogue = otherText.gameObject.GetComponent<DialoguePrinter>().getStrings();

        StartCoroutine(StartOtherConversation());
        StartCoroutine(displayText());

        text.text = dialogue[0];
        dialogueLength = a;
        otherDialogueLength = a;


        square.SetActive(true);
        text.enabled = true;

    }

    IEnumerator StartOtherConversation()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(displayOtherText());
        otherText.text = otherDialogue[0];
        otherText.gameObject.GetComponent<DialoguePrinter>().getSquare().gameObject.SetActive(true);
        otherText.enabled = true;
    }

    IEnumerator displayText()
    {
        yield return new WaitForSeconds(10);
        if(dialogueLength > 0) 
        { 
            text.text = dialogue[index];
            index++;
            dialogueLength--;
            StartCoroutine(displayText());
        }
        else
        {
            square.SetActive(false);
            text.enabled = false;
        }
    }

    IEnumerator displayOtherText()
    {
        yield return new WaitForSeconds(10);
        if (otherDialogueLength > 1)
        {
            otherText.text = otherDialogue[otherIndex];
            otherIndex++;
            otherDialogueLength--;
            StartCoroutine(displayOtherText());
        }
        else
        {
            thisDoctor.GetComponentInParent<AILerp>().speed = 1;
            otherDoctor.GetComponentInParent<AILerp>().speed = 1;
            dialogueController.setTalk();

            otherText.gameObject.GetComponent<DialoguePrinter>().getSquare().gameObject.SetActive(false);
            otherText.enabled = false;
        }
    }

    public string[] getStrings()
    {
        return dialogue;
    }

    public GameObject getSquare()
    {
        return square;
    }
}
