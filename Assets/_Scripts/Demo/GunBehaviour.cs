using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    //refs
    [SerializeField] private Transform bulletPointSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 500.0f;
    [SerializeField] private float cooldown = 0.25f;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (timer > cooldown)
            {
                CreateBullet();
                timer = 0;
            }
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
