using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainFloat : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // The amount of float movement
    public float floatSpeed = 0.5f; // The speed of the float movement
    private Vector3 startingPosition; // The initial position of the object

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startingPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
