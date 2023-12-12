using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instantiate;
    private void Awake()
    {
        Instantiate = this;
    }

    public event Action<int> onToogleSwitch;
    public void ToggleSwitchAction(int id)
    {
        if (onToogleSwitch != null)
        {
            onToogleSwitch(id);
        }
    }
}
