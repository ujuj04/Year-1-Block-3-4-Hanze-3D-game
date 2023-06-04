using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject capsule;
    [SerializeField] GameManager gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("DeathZone");
        capsule.SetActive(false);
        capsule.transform.position = new Vector3(-37.15f, 12.86f, -20.01f);
        capsule.SetActive(true);
        gameManager.IsDeathZone = true;
    }
}
