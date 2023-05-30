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



    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //bridge
        if (GameObject.Find("Bridge"))
        {
            if (!gameManager.isBridgeBuilt)
            {
                GameObject.Find("Bridge").SetActive(false);
            }
            else
            {
                GameObject.Find("Bridge").SetActive(true);
            }
        }

        //guard teleportation
        if (GameObject.Find("NPC_Dutchman_Guardian"))
        {
            if (gameManager.IsGuardTp)
            {
                gameManager.TpGuard();
            }
        }

        //rubber ducky
        if (GameObject.Find("NPC_Dutchman_Quacketty"))
        {
            if (!gameManager.IsGotQuackityCheck)
            {
                GameObject.Find("NPC_Dutchman_Quacketty").SetActive(true);
            }
            else
            {
                GameObject.Find("NPC_Dutchman_Quacketty").SetActive(false);
            }
        }
        
        //magic clock collect
        if (GameObject.Find("NPC_Object_Magic_Clock_Collect"))
        {
            if (!gameManager.IsGotMagicClockCheck)
            {
                GameObject.Find("NPC_Object_Magic_Clock_Collect").SetActive(true);
            }
            else
            {
                GameObject.Find("NPC_Object_Magic_Clock_Collect").SetActive(false);
            }
        }
    }
}
