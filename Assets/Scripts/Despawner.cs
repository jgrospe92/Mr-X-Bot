using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float lifetime = 3f;
    private Renderer rendererComponent;
    private Collider m_collider;

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        m_collider = GetComponent<Collider>();

        StartCoroutine(Disappear());
      
    }


    IEnumerator Disappear()
    {
        // Wait for 30 seconds
        yield return new WaitForSeconds(lifetime);

        // Disable the Renderer component to make the game object disappear
        rendererComponent.enabled = false;
        m_collider.enabled = false;


        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Enable the Renderer component to make the game object reappear
        rendererComponent.enabled = true;
        m_collider.enabled = true;


        // Start the Disappear coroutine again to repeat the cycle
        StartCoroutine(Disappear());
    }

}
