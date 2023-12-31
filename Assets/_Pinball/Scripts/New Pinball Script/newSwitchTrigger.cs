using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSwitchTrigger : MonoBehaviour
{
    [SerializeField] private int id;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pinball"))
        {
            GameEvents.Instantiate.ToggleSwitchAction(id);
        }
    }
}
