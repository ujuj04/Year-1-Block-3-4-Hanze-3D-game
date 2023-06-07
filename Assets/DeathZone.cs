using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject capsule;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject player;
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject cam;


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("DeathZone");
        capsule.SetActive(false);
        capsule.transform.position = new Vector3(-37.15f, 12.86f, -20.01f);
        
        //mainCamera.transform.localEulerAngles = new Vector3(0, 135, 0);
        capsule.SetActive(true); 
        //cam.transform.localEulerAngles = new Vector3(0, 135, 0);
        gameManager.IsDeathZone = true;
    }
}
