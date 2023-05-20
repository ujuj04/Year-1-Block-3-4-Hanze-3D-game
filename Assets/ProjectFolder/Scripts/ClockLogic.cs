using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClockLogic : MonoBehaviour
{

    [SerializeField] private GameManager GameManager;

    void Start()
    {
        
    }

    void Update()
    {
        //Move between Day/Night Scenes
        if (Input.GetMouseButtonDown(1))
        {
            if (GameManager.isDay == true)
            {
                Debug.Log("Changed time to night");
                SceneManager.LoadScene("NightTime");
                GameManager.isDay = false;
            }
            else
            {
                Debug.Log("Changed time to day");
                SceneManager.LoadScene("DayTime");
                GameManager.isDay = true;
            }     
        }

    }
}
