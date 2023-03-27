using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death Plane"))
        {
            
            GameManager.Instance.RestartGame();

        }
    }
}
