using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            GameManager.Instance.RestartGame();

        }
        if (other.gameObject.CompareTag("Cylinder"))
        {

            Destroy(other.gameObject);

        }
    }
}
