using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int coinsCollected;
    private int coinsTotal;
    
    

    // UI ref
    [SerializeField] private TMPro.TextMeshProUGUI coinsCollectedText;
    [SerializeField] private TMPro.TextMeshProUGUI coinsRemainingText;
    [SerializeField] private TMPro.TextMeshProUGUI winText;

    //Coins Count ref
    [SerializeField] private Transform coinsContainer;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        coinsTotal = coinsContainer.childCount;
        coinsRemainingText.text = $"Coins Remaining: {coinsTotal - coinsCollected}";
    }

    public void AddCoin()
    {
        // Add coin
        coinsCollected++;
        Debug.Log($"Coins: {coinsCollected}");

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
    }
}
