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
            CreateBullet(); 
            //StartCoroutine(CreateBullet());
        }
        

        /*if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
    }

    private void CreateBullet()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, bulletPointSpawn.position, bulletPointSpawn.rotation);

        bulletClone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * speed);
    }

    /*private IEnumerator Shoot()
    {
        yiled return new WaitForSeconds(0.1f);
    }*/

    
}
