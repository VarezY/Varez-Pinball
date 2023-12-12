using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public new static GameEvents Instantiate { get; private set; }
    private void Awake()
    {
        if (Instantiate != null && Instantiate != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instantiate = this; 
        }
    }

    public event Action<int> ONToogleSwitch;
    public void ToggleSwitchAction(int id)
    {
        if (ONToogleSwitch != null)
        {
            ONToogleSwitch(id);
        }
    }

    public event Action<Transform> ONBumpBumper;
    public void BumbBumperAction(Transform pos)
    {
        if (ONBumpBumper != null)
        {
            ONBumpBumper(pos);
        }
    }

    public event Action<int> ADDScore;
    public void UpdateScore(int score)
    {
        if (ADDScore != null)
        {
            ADDScore(score);
        }
    }
}
