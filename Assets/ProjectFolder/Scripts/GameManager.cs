using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //[SerializeField] public SceneInfo sceneInfo;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogueManager;
    [SerializeField] private GameObject worldChangesDay;
    public bool isDay = true;
    public bool isBridgeBuilt = false;
    public bool isGuardBribed = false;


    private void Awake()
    {
        if (GameManager.Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(dialogueManager);
        DontDestroyOnLoad(worldChangesDay);
    }


    //Bridge Vars setup for Dialogue System
    public bool GetIsBridgeBuilt() { return isBridgeBuilt; }
    public void SetIsBridgeBuilt(bool value) { isBridgeBuilt = value; }

    // Var for Guard (get Magic clock Quest)
    public void SetIsGuardBribed(bool value) { isGuardBribed = value; }

    //Teleport from hub to Flying Dutchman
    public void TpToFlyingDutchman() { SceneManager.LoadScene("DayTime"); }

    private void OnEnable()
    {
        Lua.RegisterFunction("GetIsBridgeBuilt", this, SymbolExtensions.GetMethodInfo(() => GetIsBridgeBuilt()));
        Lua.RegisterFunction("SetIsBridgeBuilt", this, SymbolExtensions.GetMethodInfo(() => SetIsBridgeBuilt(false)));
        Lua.RegisterFunction("SetIsGuardBribed", this, SymbolExtensions.GetMethodInfo(() => SetIsGuardBribed(false)));
        Lua.RegisterFunction("TpToFlyingDutchman", this, SymbolExtensions.GetMethodInfo(() => TpToFlyingDutchman()));
    }

    


}











//Stuff I'm probably not gonna use anyway


/*public int coinsCollected;
    private int coinsTotal;*/


// UI ref
//[SerializeField] private TMPro.TextMeshProUGUI coinsCollectedText;
//[SerializeField] private TMPro.TextMeshProUGUI coinsRemainingText;
//[SerializeField] private TMPro.TextMeshProUGUI winText;


//public TMPro.TextMeshProUGUI gunShopText;

//Coins Count ref
//[SerializeField] private Transform coinsContainer;

/* private void Start()
 {
     if (GameObject.Find("coinsContainer") != null)
         coinsTotal = coinsContainer.childCount;
     //coinsRemainingText.text = $"Coins Remaining: {coinsTotal - coinsCollected}";
 }*/








/*public void AddCoin()
{
    // Add coin
    coinsCollected++;
    Debug.Log($"Coins: {coinsCollected}");

    coinsCollectedText.gameObject.SetActive( true );

    if (coinsCollectedText!= null ) 
    {
        coinsCollectedText.text = $"Coins Collected: {coinsCollected}";
    }

    if (coinsRemainingText!= null ) 
    {
        coinsRemainingText.text = $"Coins Remaining: {coinsTotal - coinsCollected}";
    }

    if (coinsCollected == coinsTotal)
    {
        //StartCoroutine(EndGame());
    }




    // Update UI

    // If all coins collected, end game.
}

private IEnumerator EndGame()
{
    if (winText!= null)
    {
        winText.text = "You Won!";
        winText.gameObject.SetActive(true);
    }

    yield return new WaitForSeconds(2);

    yield return null;

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}*/