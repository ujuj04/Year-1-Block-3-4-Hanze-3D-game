using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChanges : MonoBehaviour
{

    //[SerializeField] public SceneInfo sceneInfo;
    [SerializeField] public GameManager gameManager;
    Vector3 guardPos;

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

        //guard (get magic clock quest)
        if (GameObject.Find("NPC_Dutchman_Guardian"))
        {
            if (!gameManager.isGuardBribed)
            {
                guardPos = GameObject.Find("NPC_Dutchman_Guardian").transform.position;
                guardPos.x = 4 - 41.49208f;
                GameObject.Find("NPC_Dutchman_Guardian").transform.position = guardPos;
            }
            else
            {
                guardPos = GameObject.Find("NPC_Dutchman_Guardian").transform.position;
                guardPos.x = 5 - 41.49208f;
                GameObject.Find("NPC_Dutchman_Guardian").transform.position = guardPos;
            }
        }
    }
}
