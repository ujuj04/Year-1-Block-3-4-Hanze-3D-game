using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class GunShop : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.coinsCollected == 4)
        {
            // Destroy fake gun in shop
            Destroy(this.transform.parent.gameObject);

            // Activate the gun in hands
            gun.gameObject.SetActive(true);

            //Destroy UI
            GameManager.Instance.gunShopText.gameObject.SetActive(false);
        }
        else
            GameManager.Instance.gunShopText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.gunShopText.gameObject.SetActive(false);
    }
}
