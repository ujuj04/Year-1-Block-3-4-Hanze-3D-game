using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move from main menu to Game
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("DayTime");
        }
    }
}
