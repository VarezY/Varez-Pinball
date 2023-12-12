using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pinball"))
        {
            Debug.Log("Game Over");
            gameOverUI.SetActive(true);
        }
    }
}
