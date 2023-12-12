using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBumperController : MonoBehaviour
{
    [Header("Bumper Configuration")]
    [SerializeField, Range(1f,2f)]
    private float speedMultiplier;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            GameEvents.Instantiate.BumbBumperAction(transform);
            
            Rigidbody bolaRig = other.gameObject.GetComponent<Rigidbody>();
            bolaRig.velocity *= speedMultiplier;
        }
    }

}
