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

        if (other.gameObject.CompareTag("Death Plane"))
        {
            GameManager.Instance.RestartGame();

        }

    }
}
