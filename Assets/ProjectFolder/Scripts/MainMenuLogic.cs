using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Move from main menu to Game
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("DayTime");
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            SceneManager.LoadScene("Maze_DayTime");
        }
    }
}
