using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    public void ExitGame() 
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
