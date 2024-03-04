using OpenAI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Attributes : MonoBehaviour
{
    public GameObject otherTemp;
    public string description;
    public string name;

    private string modelUsed = "gpt-4-0613";

    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();

    private TMP_Text text;

    private GameObject Doctor;

    void Start()
    {
        Doctor = this.transform.parent.gameObject;
        text = GetComponentInChildren<TMP_Text>();
        openAI = new OpenAIApi("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");
        AskChatGPTAsync();
        text.enabled = false;
    }

    public async void AskChatGPTAsync()
    {
        Debug.Log("HERE");
        ChatMessage character = new ChatMessage();
        character.Role = "user";
        character.Content = "Make me a character for my game. Here is an example. Make sure they work in a facility, that focuses on experimental advanced technology in many fields, such as military, science, agriculture etc. Here is the example" +
                    "Name: Elina\r\n\r\nBackground: Elina hails from a distant country, bringing with her a rich cultural heritage and an eagerness to adapt to new surroundings. However, she struggles with the English language. Her sentences are often jumbled, and she frequently mixes up tenses and prepositions, making her communication unique and sometimes challenging to understand.\r\n\r\nRole in the Facility: Elina works in a high-tech research facility, specializing in botanical research. Her job involves experimenting with plant genetics to develop new forms of sustainable food sources. Despite her language barrier, her expertise in botany and her innovative approach to plant genetics make her an invaluable asset to the team.\r\n\r\nPersonality Traits: She is incredibly patient and observant, often noticing details that others overlook. Elina is also very kind-hearted and always willing to help her colleagues, even if it means going out of her way to communicate effectively. Her perseverance in the face of language barriers inspires those around her.\r\n\r\nAppearance: Elina has a distinctive style that blends elements from her cultural background with practical work attire. She often wears brightly colored scarves and accessories that contrast with her standard-issue lab coat, making her stand out among her peers.\r\n\r\nPet: Unlike Tom, Elina doesn't have a pet dog. Instead, she keeps a small aquarium in her living quarters within the facility, where she carefully tends to a collection of exotic fish. Her fascination with life in all its forms extends from her professional work to her personal hobbies. The aquarium serves as a relaxing sanctuary for her, a place where she can find peace and solace away from the complexities of language and human interaction.\r\n\r\nUnique Quirk: Elina has a habit of singing softly in her native language while working on her experiments. Her colleagues have grown fond of this, finding the melodies soothing and adding a layer of warmth to the sterile environment of the research facility.\r\n";

        messages.Add(character);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = modelUsed;

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            description = chatResponse.Content;
            Debug.Log(description);
            Debug.Log(chatResponse.Content);
            //OnResponse.Invoke(chatResponse.Content);
        }

        character.Role = "user";
        character.Content = "Tell me the name of the character you created. Dont say anything else";
        messages.Add(character);

        request.Messages = messages;
        request.Model = modelUsed;

        response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            name = chatResponse.Content;
            text.enabled = true;
            text.text = name;
            //StartCoroutine(time());
        }
    }

    public string getName()
    {
        return name;
    }

    public string getDescription() 
    { 
        return description;
    }

    private void Update()
    {
        if (Doctor.transform.localScale.x < 0)
        {
            text.gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            text.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }
    public async void chat(string response, int i)
    {
        if (i > 0)
        {
            i--;
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(15);
        this.gameObject.GetComponent<DialogueController>().setContext(otherTemp);
    }
}
