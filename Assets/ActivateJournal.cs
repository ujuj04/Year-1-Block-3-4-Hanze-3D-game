using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class ActivateJournal : MonoBehaviour
{
    [ConversationPopup(true)] public string conversation;
    [SerializeField] GameObject journalIcon;
    [SerializeField] GameObject fader;
    public bool isTimeSwitch = false;

    

    void Update()
    {

        if (!DialogueManager.isConversationActive && Input.GetKeyDown(KeyCode.J))
        {
            var player = GameObject.FindWithTag("Player");
            DialogueManager.StartConversation(conversation, player.transform);
        }
        else if (!DialogueManager.isConversationActive && !Input.GetKeyDown(KeyCode.J) && !(fader.activeSelf) && !(SceneManager.GetActiveScene().name == "Maze_DayTime") && !(SceneManager.GetActiveScene().name == "Maze_NightTime"))
        {
            journalIcon.SetActive(true);
        }
        else if (DialogueManager.isConversationActive || fader.activeSelf || (SceneManager.GetActiveScene().name == "Maze_DayTime") || (SceneManager.GetActiveScene().name == "Maze_NightTime"))
        {
            journalIcon.SetActive(false);
        }
    }
}
