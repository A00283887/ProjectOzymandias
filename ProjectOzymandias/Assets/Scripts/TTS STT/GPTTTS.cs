using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using System.Threading.Tasks;
using UnityEngine.Events;

public class GPTTTS : MonoBehaviour
{
    public OnResponseEvent OnResponse;
    public string Instruction;
    public string modelUsed = "gpt-3.5-turbo";
    private string chatText;

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { }

    private OpenAIApi openAI;
    private List<ChatMessage> messages = new List<ChatMessage>();

    private void Start()
    {
        openAI = new OpenAIApi("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");
    }

    public void getInstruction(string instruction)
    {
        Instruction = instruction;
    }

    public async void AskChatGPTAsync(string newText)
    {

        ChatMessage character = new ChatMessage();
        character.Content = Instruction;
        character.Role = "system";
        messages.Add(character);

        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";

        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = modelUsed;

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            chatText = chatResponse.Content;
            Debug.Log(chatResponse.Content);
            OnResponse.Invoke(chatResponse.Content);
        }
    }

    public string getResponse()
    {
        return chatText;
    }

    public string getModel()
    {
        return modelUsed;
    }

    private void Update()
    {
        Debug.Log(Instruction);
    }
}