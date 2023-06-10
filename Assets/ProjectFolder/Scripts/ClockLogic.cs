using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Cinemachine;
using StarterAssets;

public class ClockLogic : MonoBehaviour
{
    //[SerializeField] public SceneInfo sceneInfo; 
    [SerializeField] public GameManager gameManager;
    [SerializeField] RectTransform fader;
    [SerializeField] FirstPersonController controller;
    private string sceneToLoad = "";

    void Update()
    {

        //Move between Day/Night Scenes

        if (Input.GetKeyDown(KeyCode.T) && SceneManager.GetActiveScene().name != "Hub" && SceneManager.GetActiveScene().name != "DeathZone" && !PixelCrushers.DialogueSystem.DialogueManager.isConversationActive)
        {
            if (SceneManager.GetActiveScene().name == "DayTime" || SceneManager.GetActiveScene().name == "NightTime")
                if (gameManager.isDay == true)
                {
                    sceneToLoad = "NightTime";
                    gameManager.isDay = false;
                }
                else
                {
                    sceneToLoad = "DayTime";
                    gameManager.isDay = true;
                }
            if (SceneManager.GetActiveScene().name == "Maze_DayTime" || SceneManager.GetActiveScene().name == "Maze_NightTime")
                if (gameManager.mazeIsDay == true)
                {
                    sceneToLoad = "Maze_NightTime";
                    gameManager.mazeIsDay = false;
                }
                else
                {
                    sceneToLoad = "Maze_DayTime";
                    gameManager.mazeIsDay = true;
                }
            LoadSceneAndPlayAnimation();
        }
    }
    private void LoadSceneAndPlayAnimation()
    {

        //Disable player movement
        controller.enabled = false;

        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.rotate(fader, Vector3.zero, 0f);
        LeanTween.rotateAround(fader, Vector3.forward, -360, 0.7f);
        LeanTween.scale(fader, new Vector3 (1, 1, 1), 0.7f).setEase(LeanTweenType.easeInExpo).setOnComplete(() => {
            SceneManager.LoadScene(sceneToLoad);
            LeanTween.scale(fader, Vector3.zero, 0.7f).setEase(LeanTweenType.easeOutQuad);
            LeanTween.rotateAround(fader, Vector3.forward, 360, 0.7f).setOnComplete(() =>
            {
                //Enable player movement
                controller.enabled = true;
            } );
        });
    }
}
