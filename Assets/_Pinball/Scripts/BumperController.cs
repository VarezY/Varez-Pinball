using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [Range(1f,2f)]
    public float speedMultiplier;

    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private VFXManager _vfxManager;

    private void OnCollisionEnter(Collision collision)
    {
        // memastikan yang menabrak adalah bola
        if (collision.gameObject.CompareTag("Pinball"))
        {
            // Play SFX & VFX
            var position = transform.position;
            _audioManager.PlayBumperSFX(position);
            _vfxManager.PlayBumperVFX(position);
            
            // kita lakukan debug
            Rigidbody bolaRig = collision.gameObject.GetComponent<Rigidbody>();
            bolaRig.velocity *= speedMultiplier;
        }
    }
}
