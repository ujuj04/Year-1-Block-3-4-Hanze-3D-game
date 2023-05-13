using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] private ParticleSystem splatterPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        ParticleSystem splatterClone = Instantiate(splatterPrefab, transform.position, transform.rotation);
        Destroy(splatterClone, 1f);
    }
}
