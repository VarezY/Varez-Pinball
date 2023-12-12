using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    [SerializeField] private int point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pinball"))
        {
            GameEvents.Instantiate.UpdateScore(point);
        }
    }
}
