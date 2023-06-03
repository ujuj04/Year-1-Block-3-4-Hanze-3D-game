using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClockLogic : MonoBehaviour
{
    //[SerializeField] public SceneInfo sceneInfo; 
    [SerializeField] public GameManager gameManager;
    void Update()
    {
        //Move between Day/Night Scenes
        if (Input.GetMouseButtonDown(1))
        {
            if (SceneManager.GetActiveScene().name == "DayTime" || SceneManager.GetActiveScene().name == "NightTime")
                if (gameManager.isDay == true)
                {
                    SceneManager.LoadScene("NightTime");
                    gameManager.isDay = false;
                }
                else
                {
                    SceneManager.LoadScene("DayTime");
                    gameManager.isDay = true;
                }    
            if (SceneManager.GetActiveScene().name == "Maze_DayTime" || SceneManager.GetActiveScene().name == "Maze_NightTime")
                if (gameManager.mazeIsDay == true)
                {
                    Debug.Log("2");
                    SceneManager.LoadScene("Maze_NightTime");
                    gameManager.mazeIsDay = false;
                }
                else
                {
                    Debug.Log("1");
                    SceneManager.LoadScene("Maze_DayTime");
                    gameManager.mazeIsDay = true;
                }     
        }

    }
}
