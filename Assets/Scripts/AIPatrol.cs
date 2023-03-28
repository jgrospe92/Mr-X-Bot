using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3 directionA;
    public Vector3 directionB;
  

    private bool movingToA;

    void Start()
    {
        movingToA = false;
        
    }

    void Update()
    {
        if (movingToA)
        {
            transform.Translate(directionA * moveSpeed * Time.deltaTime);
        }

        else
        {
            transform.Translate(directionB * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            movingToA = !movingToA;
        }

        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.RestartGame();
        }
    }

}
