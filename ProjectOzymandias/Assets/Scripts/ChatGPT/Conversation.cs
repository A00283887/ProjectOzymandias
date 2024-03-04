using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConversationEntry
{
    public List<string> lines = new List<string>();
}

[CreateAssetMenu(fileName = "NewConversation", menuName = "Conversation System/Conversation", order = 1)]
public class Conversation : ScriptableObject
{
    public List<ConversationEntry> conversations = new List<ConversationEntry>();
}