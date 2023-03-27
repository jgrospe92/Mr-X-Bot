using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public CharacterMovement cm;
    public ParticleSystem blueParticle;
    public ParticleSystem yellowParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Stone"))
        {
            //cm.gameObject.GetComponent<CharacterMovement>().isDoubleJumping = true;
            blueParticle.Play();
            cm.isDoubleJumping = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Yellow Stone"))
        {
            //cm.gameObject.GetComponent<CharacterMovement>().isDoubleJumping = true;
            yellowParticle.Play();
            //cm.isDoubleJumping = true;
            Destroy(other.gameObject);
        }
    }
}
