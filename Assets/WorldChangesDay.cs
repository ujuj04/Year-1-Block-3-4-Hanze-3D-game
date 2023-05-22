using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChangesDay : MonoBehaviour
{

    //[SerializeField] public SceneInfo sceneInfo;
    [SerializeField] public GameManager gameManager;

    void Start()
    {
        
    }

    private void Update()
    {
        if (gameManager.isDay == true) 
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
}
