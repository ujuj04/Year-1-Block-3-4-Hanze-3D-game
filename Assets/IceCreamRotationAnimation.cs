using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamRotationAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(0f, 0f , 100f * Time.deltaTime, Space.Self);
    }
}
