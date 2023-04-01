using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCollect : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            // Destroy the coin's parent object
            Destroy(this.transform.gameObject);
            Destroy(door.transform.gameObject);
        }
    }
}
