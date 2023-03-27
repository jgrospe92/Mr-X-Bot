using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnim : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public float floatAmplitude = 0.5f;
    public float floatFrequency = 1f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Compute the floating motion using a sinusoidal function
        float floatOffset = floatAmplitude * Mathf.Sin(floatFrequency * Time.time);
        Vector3 floatPosition = startPosition + new Vector3(0f, floatOffset, 0f);

        // Set the object's position to the floating position
        transform.position = floatPosition;

    }
}
