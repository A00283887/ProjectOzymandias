using OpenAI;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private ClockScript cs;
    private DoctorMove dm;
    public GameObject otherTemp;
    public int a;

    public TMP_Text otherText;

    private float time = 0f;
    public bool onElevator = false;

    public bool canTalk = false;

    private bool startConversation = false;
    public bool cooldown = true;

    public string messageRespone;

    //private string modelUsed = "gpt-4-0613";
    private string modelUsed = "gpt-4-0125-preview";

    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();
    CreateChatCompletionRequest request = new CreateChatCompletionRequest();

    private string responseMessage = "";
    public string[] responses;

    public string conversation = "";

    ChatMessage character;
    ChatMessage character2;

    public DialoguePrinter dialoguePrinter;
    public DialoguePrinter otherDialoguePrinter;

    void Start()
    {
        openAI = new OpenAIApi("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");

        cs = GameObject.Find("TABMenu").GetComponent<ClockScript>();
        dm = this.GetComponentInParent<DoctorMove>();

        if (canTalk)
        {
            StartCoroutine(tempTest());
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = cs.getTimer();
        //onElevator = dm.CheckIfOnElevator();

        if (time > 780f && time < 900f && !onElevator)
        {
            canTalk = true;
        }
        else
        {
            // canTalk = false;
        }

        if (canTalk)
        {
            //canTalk = false;
        }
    }

    public bool GenerateStartConversation()
    {
        a = Random.Range(0, 2);  // Random number from 0 to 1
        if (a == 0)
            return false;
        else
            return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Doctor")
        {
            if (canTalk)
            {
                fullConversation(other.gameObject);
                this.gameObject.GetComponentInParent<AILerp>().speed = 0;

                Animator thisAnimator = this.gameObject.GetComponentInParent<Animator>();
                Animator otherAnimator = other.gameObject.GetComponentInParent<Animator>();

                thisAnimator.SetBool("run", false);
                thisAnimator.SetBool("Idle", true);

                otherAnimator.SetBool("run", false);
                otherAnimator.SetBool("Idle", true);
                other.gameObject.GetComponentInParent<AILerp>().speed = 0;

                canTalk = false;
            }
        }
    }

    public async void setContext(GameObject other)
    {
        character = new ChatMessage();
        character.Role = "system";
        character.Content = "You are playing this character: " + this.gameObject.GetComponent<Attributes>().getDescription() + ". I will the playing the following character: " + other.gameObject.GetComponent<Attributes>().getDescription() + ". I want you to respond to me as if you are the first character. Keep your responses under 150 characters long";
        messages.Add(character);
    }

    public async void setContext2(GameObject other)
    {
        character2 = new ChatMessage();
        character2.Role = "system";
        character2.Content = "You are playing this character: " + other.gameObject.GetComponent<Attributes>().getDescription() + ". I will the playing the following character: " + this.gameObject.GetComponent<Attributes>().getDescription() + ". I want you to respond to me as if you are the first character. Keep your responses under 150 characters long";
        messages.Add(character2);
    }


    public async void fullConversation(GameObject other)
    {
        otherTemp = other;
        setContext(otherTemp);
        setContext2(this.gameObject);
        character.Role = "user";
        character.Content = "Start the conversation. We just stumbled across eachother in the facility. Make sure you keep it under 150 characters long, and only use dialogue, no describing your characters actions.";
        messages.Add(character);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = modelUsed;

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            messageRespone = chatResponse.Content;
            other.gameObject.GetComponent<DialogueController>().setResponse(messageRespone);
            dialoguePrinter.addToDialogue(0, messageRespone);
        }
        conversation += messageRespone;

        character2.Role = "user";
        character2.Content = messageRespone;
        messages.Add(character2);

        request.Messages = messages;
        request.Model = modelUsed;

        response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            messageRespone = chatResponse.Content;
            otherDialoguePrinter.addToDialogue(0, messageRespone);
        }
        conversation += messageRespone;

        a = Random.Range(3, 5);
        while (a % 2 != 1)
        {
            a = Random.Range(0, 4);
        }

        for (int i = 0; i < a; i++)
        {
            if (i == a - 1)
            {

                character.Role = "user";
                character.Content = "End the conversation. Say goodbye to my character. Make sure you keep it under 150 characters long, and only use dialogue, no describing your characters actions.";
                messages.Add(character);

                request.Messages = messages;
                request.Model = modelUsed;

                response = await openAI.CreateChatCompletion(request);

                if (response.Choices != null && response.Choices.Count > 0)
                {
                    var chatResponse = response.Choices[0].Message;
                    messages.Add(chatResponse);
                    messageRespone = chatResponse.Content;
                    other.gameObject.GetComponent<DialogueController>().setResponse(messageRespone);
                    dialoguePrinter.addToDialogue(i+1, messageRespone);
                    conversation += messageRespone;
                    dialoguePrinter.StartConversation(a, other.gameObject.GetComponent<DialogueController>(), otherText);
                }

            }
            else
            {
                if (cooldown)
                {
                    character.Role = "user";
                    character.Content = responseMessage;
                    messages.Add(character);

                    request.Messages = messages;
                    request.Model = modelUsed;

                    response = await openAI.CreateChatCompletion(request);

                    if (response.Choices != null && response.Choices.Count > 0)
                    {
                        var chatResponse = response.Choices[0].Message;
                        messages.Add(chatResponse);
                        messageRespone = chatResponse.Content;
                        conversation += messageRespone;
                        dialoguePrinter.addToDialogue(i + 1, messageRespone);
                    }

                    character2.Role = "user";
                    character2.Content = messageRespone;
                    messages.Add(character2);

                    request.Messages = messages;
                    request.Model = modelUsed;

                    response = await openAI.CreateChatCompletion(request);

                    if (response.Choices != null && response.Choices.Count > 0)
                    {
                        var chatResponse = response.Choices[0].Message;
                        messages.Add(chatResponse);
                        messageRespone = chatResponse.Content;
                        conversation += messageRespone;
                        otherDialoguePrinter.addToDialogue(i + 1, messageRespone);

                    }
                }
            }
        }

    }

    public async void startTheConversation(GameObject other)
    {
        character.Role = "user";
        character.Content = "Start the conversation. We just stumbled across eachother in the facility. Make sure you keep it within max 150 letters, and only use dialogue.";
        messages.Add(character);

        request.Messages = messages;
        request.Model = modelUsed;

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            messageRespone = chatResponse.Content;
            other.gameObject.GetComponent<DialogueController>().setResponse(messageRespone);
            conversation += messageRespone;

        }
    }

    public async void chat(GameObject other)
    {
        if (cooldown)
        {
            character.Role = "user";
            character.Content = responseMessage;
            messages.Add(character);

            request.Messages = messages;
            request.Model = modelUsed;

            var response = await openAI.CreateChatCompletion(request);

            if (response.Choices != null && response.Choices.Count > 0)
            {
                var chatResponse = response.Choices[0].Message;
                messages.Add(chatResponse);
                messageRespone = chatResponse.Content;
                other.gameObject.GetComponent<DialogueController>().setResponse(messageRespone);
                conversation += messageRespone;
                addToConversation(messageRespone);
            }
        }

    }

    public void setResponse(string message)
    {
        responseMessage = message;
    }

    public void addToConversation(string message)
    {
        conversation += message;
    }

    IEnumerator tempTest()
    {
        yield return new WaitForSeconds(20);
    }

    public void setTalk()
    { 
        canTalk = true;
    }
        
}
