using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRotationAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(0f, 100f * Time.deltaTime, 0f, Space.Self);
    }
}
