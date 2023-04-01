using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    //refs
    [SerializeField] private Transform bulletPointSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 500.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        

        /*if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
    }

    private void Shoot()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, bulletPointSpawn.position, bulletPointSpawn.rotation);

        bulletClone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * speed);
    }
}
