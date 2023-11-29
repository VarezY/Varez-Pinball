using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler : MonoBehaviour
{
    public List<SwitchController> _Switches;

    private void Somethin()
    {
        if (_Switches[0]._isOn )
        {
            // SOmething
        }
    }
}
