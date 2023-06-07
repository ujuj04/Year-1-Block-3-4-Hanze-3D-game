using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ClockLogic : MonoBehaviour
{
    //[SerializeField] public SceneInfo sceneInfo; 
    [SerializeField] public GameManager gameManager;
    void Update()
    {
        //Move between Day/Night Scenes
        if (Input.GetKeyDown(KeyCode.T) && SceneManager.GetActiveScene().name != "Hub" && SceneManager.GetActiveScene().name != "DeathZone" && !PixelCrushers.DialogueSystem.DialogueManager.isConversationActive)
        {
            if (SceneManager.GetActiveScene().name == "DayTime" || SceneManager.GetActiveScene().name == "NightTime")
                if (gameManager.isDay == true)
                {
                    SceneManager.LoadScene("NightTime");
                    Cursor.visible = false;
                    gameManager.isDay = false;
                }
                else
                {
                    SceneManager.LoadScene("DayTime");
                    Cursor.visible = false;
                    gameManager.isDay = true;
                }    
            if (SceneManager.GetActiveScene().name == "Maze_DayTime" || SceneManager.GetActiveScene().name == "Maze_NightTime")
                if (gameManager.mazeIsDay == true)
                {
                    Debug.Log("2");
                    SceneManager.LoadScene("Maze_NightTime");
                    Cursor.visible = false;
                    gameManager.mazeIsDay = false;
                }
                else
                {
                    Debug.Log("1");
                    SceneManager.LoadScene("Maze_DayTime");
                    Cursor.visible = false;
                    gameManager.mazeIsDay = true;
                }     
        }

    }
}
