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
    [SerializeField] private GameObject magicClock;
    public bool isDay = true;
    public bool isBridgeBuilt = false;
    public bool isGuardBribed = false;
    public bool IsGotQuackityCheck = false;
    public bool IsGuardTp = false;
    public bool IsGotMagicClockCheck = false;
    Vector3 guardPos;


    private void Awake()
    {
        if (GameManager.Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(dialogueManager);
        DontDestroyOnLoad(worldChangesDay);
    }


    // Vars Bridge 
    public bool GetIsBridgeBuilt() { return isBridgeBuilt; }
    public void SetIsBridgeBuilt(bool value) { isBridgeBuilt = value; }

    // Var for Guard (get Magic clock Quest)
    public void SetIsGuardBribed(bool value) { isGuardBribed = value; }

    //Teleport from hub to Flying Dutchman
    public void TpToFlyingDutchman() { SceneManager.LoadScene("DayTime"); }

    //Teleport the guard and save var
    public void TpGuard() 
    {
        guardPos = GameObject.Find("NPC_Dutchman_Guardian").transform.position;
        guardPos.x = 5 - 41.49208f;
        GameObject.Find("NPC_Dutchman_Guardian").transform.position = guardPos;
    }
    public void SetIsGuardTp(bool value) { IsGuardTp = value; }

    //Var for rubber ducky
    public void SetIsGotQuackityCheck(bool value) { IsGotQuackityCheck = value; }

    //Var for collecting the magic clock
    public void SetIsGotMagicClockCheck(bool value) { IsGotMagicClockCheck = value; }

    //Activate the magic clock
    public void ActivateMagicClock() 
    {
        magicClock.SetActive(true);
    }

    //Methods transition to Lua
    private void OnEnable()
    {
        Lua.RegisterFunction("GetIsBridgeBuilt", this, SymbolExtensions.GetMethodInfo(() => GetIsBridgeBuilt()));
        Lua.RegisterFunction("SetIsBridgeBuilt", this, SymbolExtensions.GetMethodInfo(() => SetIsBridgeBuilt(false)));
        Lua.RegisterFunction("SetIsGuardBribed", this, SymbolExtensions.GetMethodInfo(() => SetIsGuardBribed(false)));
        Lua.RegisterFunction("TpToFlyingDutchman", this, SymbolExtensions.GetMethodInfo(() => TpToFlyingDutchman()));
        Lua.RegisterFunction("TpGuard", this, SymbolExtensions.GetMethodInfo(() => TpGuard()));
        Lua.RegisterFunction("SetIsGotQuackityCheck", this, SymbolExtensions.GetMethodInfo(() => SetIsGotQuackityCheck(false)));
        Lua.RegisterFunction("SetIsGuardTp", this, SymbolExtensions.GetMethodInfo(() => SetIsGuardTp(false)));
        Lua.RegisterFunction("SetIsGotMagicClockCheck", this, SymbolExtensions.GetMethodInfo(() => SetIsGotMagicClockCheck(false)));
        Lua.RegisterFunction("ActivateMagicClock", this, SymbolExtensions.GetMethodInfo(() => ActivateMagicClock()));
    }
}