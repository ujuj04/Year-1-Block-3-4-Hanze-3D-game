using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the coin's parent object
            Destroy(this.transform.parent.gameObject);

            // Add points
            //GameManager.Instance.AddCoin();
        }
    }
}
