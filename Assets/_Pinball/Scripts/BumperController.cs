using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [Range(1f,2f)]
    public float speedMultiplier;
    private void OnCollisionEnter(Collision collision)
    {
        // memastikan yang menabrak adalah bola
        if (collision.gameObject.tag == "Pinball")
        {
            // kita lakukan debug
            Rigidbody bolaRig = collision.gameObject.GetComponent<Rigidbody>();
            bolaRig.velocity *= speedMultiplier;
        }
    }

    
}
