using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ActivateJournal : MonoBehaviour
{
    [ConversationPopup(true)] public string conversation;

    void Update()
    {
        if (!DialogueManager.isConversationActive && Input.GetKeyDown(KeyCode.J))
        {
            var player = GameObject.FindWithTag("Player");
            DialogueManager.StartConversation(conversation, player.transform);
        }
    }
}
