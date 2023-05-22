using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClockLogic : MonoBehaviour
{
    //[SerializeField] public SceneInfo sceneInfo; 
    [SerializeField] public GameManager gameManager;
    void Start()
    {
        
    }

    void Update()
    {
        //Move between Day/Night Scenes
        if (Input.GetMouseButtonDown(1))
        {
            if (gameManager.isDay == true)
            {
                Debug.Log("Changed time to night");
                SceneManager.LoadScene("NightTime");
                gameManager.isDay = false;
            }
            else
            {
                Debug.Log("Changed time to day");
                SceneManager.LoadScene("DayTime");
                gameManager.isDay = true;
            }     
        }

    }
}
