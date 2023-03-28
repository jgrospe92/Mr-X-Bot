using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public CharacterMovement cm;
    public ParticleSystem blueParticle;
    public ParticleSystem yellowParticle;
    private int yellowPts = 50;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Stone"))
        {
            
            blueParticle.Play();
            cm.isDoubleJumping = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Yellow Stone"))
        {
       
            yellowParticle.Play();
            GameManager.instance.UpdateScore(yellowPts);
         
            Destroy(other.gameObject);
        }

    

        if (other.gameObject.CompareTag("Finish"))
        {
            print("finish");
            GameManager.Instance.NextLevel();
        }


    }


    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.tag == "Cylinder")
    //    {
    //        GameManager.Instance.RestartGame();
    //    }
    //}
}
