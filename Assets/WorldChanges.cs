using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChanges : MonoBehaviour
{

    //[SerializeField] public SceneInfo sceneInfo;
    [SerializeField] public GameManager gameManager;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void Start()
    {
        
    }



    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //bridge
        if (GameObject.Find("Bridge"))
            if (!gameManager.isBridgeBuilt)
            {
                GameObject.Find("Bridge").SetActive(false);
            }
            else
            {
                GameObject.Find("Bridge").SetActive(true);
            }
    }
}
