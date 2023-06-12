using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //[SerializeField] public SceneInfo sceneInfo;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogueManager;
    [SerializeField] private GameObject worldChangesDay;
    [SerializeField] private GameObject magicClock;
    [SerializeField] private GameObject deathZone;
    [SerializeField] private Canvas canvas;
    [SerializeField] GameObject capsule;
    [SerializeField] SAudioManager audioManager;
    public bool isDay = true;
    public bool mazeIsDay = true;
    public bool isBridgeBuilt = false;
    public bool isGuardBribed = false;
    public bool IsGotQuackityCheck = false;
    public bool IsGuardTp = false;
    public bool IsGotMagicClockCheck = false;
    public bool IsGotKey = false;
    public bool IsDeathZone = false;
    Vector3 guardPos;
    Vector3 playerDreamPos;


    private void Awake()
    {
        if (GameManager.Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(dialogueManager);
        DontDestroyOnLoad(worldChangesDay);
        DontDestroyOnLoad(deathZone);
        DontDestroyOnLoad(canvas);
        Application.targetFrameRate = 60;
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
        guardPos.x = 5.5f - 41.49208f;
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

    //Var for key
    public void SetIsGotKey(bool value) { IsGotKey = value; }

    //Time check
    public bool GetDay() { return isDay; }

    //Tp to captain's dream
    public void TpToCaptainDream() { SceneManager.LoadScene("Maze_DayTime"); }

    //Tp from captain's dream
    public void TpFromCaptainDream()
    {
        SceneManager.LoadScene("NightTime");
        capsule.SetActive(false);
        capsule.transform.position = new Vector3(-68f, 1.2f, -5f);
        capsule.SetActive(true);
    }

    //Var for DeathZone
    public bool GetIsDeathZone() { return IsDeathZone; }

    //Tp player to the end game
    public void EndGame()
    {
        capsule.SetActive(false);
        capsule.transform.position = new Vector3(-40f, 12.86f, -5.01f);
        capsule.SetActive(true);
        SceneManager.LoadScene("DeathZone"); 
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        player.SetActive(false);
    }

    public void DeathVoiceLine()
    {
        audioManager.Play("DeathVoiceLine");
    }
    public void DutchmanCaptainVoiceLine()
    {
        audioManager.Play("DutchmanCaptainVoiceLine");
    }
    public void DrunkSkeletonVoiceLine()
    {
        audioManager.Play("DrunkSkeletonVoiceLine");
    }
    public void HumansVoiceLine()
    {
        audioManager.Play("HumansVoiceLine");
    }
    public void BridgerVoiceLine()
    {
        audioManager.Play("BridgerVoiceLine");
    }
    public void GuardsVoiceLine()
    {
        audioManager.Play("GuardsVoiceLine");
    }
    public void EnglishCaptainVoiceLine()
    {
        audioManager.Play("EnglishCaptainVoiceLine");
    }
    public void PoetVoiceLine()
    {
        audioManager.Play("PoetVoiceLine");
    }
    public void RichVoiceLine()
    {
        audioManager.Play("RichVoiceLine");
    }
    public void QuackettyVoiceLine()
    {
        audioManager.Play("QuackettyVoiceLine");
    }
    public void DrinkGrogVoiceLine()
    {
        audioManager.Play("DrinkGrogVoiceLine");
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
        Lua.RegisterFunction("GetDay", this, SymbolExtensions.GetMethodInfo(() => GetDay()));
        Lua.RegisterFunction("SetIsGotKey", this, SymbolExtensions.GetMethodInfo(() => SetIsGotKey(false)));
        Lua.RegisterFunction("TpToCaptainDream", this, SymbolExtensions.GetMethodInfo(() => TpToCaptainDream()));
        Lua.RegisterFunction("TpFromCaptainDream", this, SymbolExtensions.GetMethodInfo(() => TpFromCaptainDream()));
        Lua.RegisterFunction("GetIsDeathZone", this, SymbolExtensions.GetMethodInfo(() => GetIsDeathZone()));
        Lua.RegisterFunction("EndGame", this, SymbolExtensions.GetMethodInfo(() => EndGame()));
        Lua.RegisterFunction("Credits", this, SymbolExtensions.GetMethodInfo(() => Credits()));
        Lua.RegisterFunction("DeathVoiceLine", this, SymbolExtensions.GetMethodInfo(() => DeathVoiceLine()));
        Lua.RegisterFunction("DutchmanCaptainVoiceLine", this, SymbolExtensions.GetMethodInfo(() => DutchmanCaptainVoiceLine()));
        Lua.RegisterFunction("DrunkSkeletonVoiceLine", this, SymbolExtensions.GetMethodInfo(() => DrunkSkeletonVoiceLine()));
        Lua.RegisterFunction("HumansVoiceLine", this, SymbolExtensions.GetMethodInfo(() => HumansVoiceLine()));
        Lua.RegisterFunction("BridgerVoiceLine", this, SymbolExtensions.GetMethodInfo(() => BridgerVoiceLine()));
        Lua.RegisterFunction("GuardsVoiceLine", this, SymbolExtensions.GetMethodInfo(() => GuardsVoiceLine()));
        Lua.RegisterFunction("EnglishCaptainVoiceLine", this, SymbolExtensions.GetMethodInfo(() => EnglishCaptainVoiceLine()));
        Lua.RegisterFunction("PoetVoiceLine", this, SymbolExtensions.GetMethodInfo(() => PoetVoiceLine()));
        Lua.RegisterFunction("RichVoiceLine", this, SymbolExtensions.GetMethodInfo(() => RichVoiceLine()));
        Lua.RegisterFunction("QuackettyVoiceLine", this, SymbolExtensions.GetMethodInfo(() => QuackettyVoiceLine()));
        Lua.RegisterFunction("DrinkGrogVoiceLine", this, SymbolExtensions.GetMethodInfo(() => DrinkGrogVoiceLine()));
    }
}