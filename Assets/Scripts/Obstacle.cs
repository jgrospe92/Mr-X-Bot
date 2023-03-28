using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // The Rigidbody component attached to the barrel game object
    private Rigidbody rb;

    // The force to apply to move the barrel
    public float moveForce = 12f;

    // The torque to apply to roll the barrel
    public float rollTorque = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the barrel game object
        rb = GetComponent<Rigidbody>();
      
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //Add a forward force to move the barrel in the direction of the positive Z axis
        rb.AddForce(-Vector3.forward * moveForce);

        // Create a torque vector to roll the barrel
        Vector3 torque = new Vector3(0f, 0f, -1f);

        // Add a torque to the Rigidbody component to roll the barrel
        rb.AddTorque(torque * rollTorque);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.RestartGame();
        }
    }
}
