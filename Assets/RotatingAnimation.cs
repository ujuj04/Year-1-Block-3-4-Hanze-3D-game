using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(100f * Time.deltaTime, 0f, 0f, Space.Self);
    }
}
