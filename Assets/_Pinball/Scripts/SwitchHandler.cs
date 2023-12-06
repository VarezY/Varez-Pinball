using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler : MonoBehaviour
{
    [Header("SFX & VFX")]
    [SerializeField] 
    private AudioManager _audioManager;

    [SerializeField] private VFXManager _vfxManager;
    
    [Header("Switches")]
    [SerializeField]
    private List<SwitchController> _switch;

    private List<SwitchController> _switchContainer = new List<SwitchController>();

    private void Start()
    {
        InisiateSwitch();
    }

    private void OnDestroy()
    {
        SwitchController[] switchList = _switch.ToArray();
        
        for (int i = 0; i < switchList.Length; i++)
        {
            _switch.Add(switchList[i]);
            switchList[i]._OnTriggerEnterSwitch -= OnToggleSwitchEnter;
            switchList[i]._OnTriggerEnterSwitch -= PlaySfxSwitch;
            switchList[i]._OnTriggerEnterSwitch -= PlayVfxSwitch;
        }
    }
    
    private void InisiateSwitch()
    {
        SwitchController[] switchList = _switch.ToArray();
        
        for (int i = 0; i < switchList.Length; i++)
        {
            switchList[i]._OnTriggerEnterSwitch += OnToggleSwitchEnter;
            switchList[i]._OnTriggerEnterSwitch += PlaySfxSwitch;
            switchList[i]._OnTriggerEnterSwitch += PlayVfxSwitch;
        }
    }

    private void PlayVfxSwitch(SwitchController obj)
    {
        _vfxManager.PlaySwitchVFX(obj.transform.position);
    }

    private void PlaySfxSwitch(SwitchController obj)
    {
        _audioManager.PlaySwitchSFX(obj.transform.position);
    }

    private void OnToggleSwitchEnter(SwitchController obj)
    {
        Debug.Log("Toggle the switch");

        if (!obj._isOn)
        {
            Debug.Log("Turn on this Switch");
        }
        else 
        {
            Debug.Log("Turn off this Switch");
        }
        obj._isOn = !obj._isOn;

        Debug.Log(BonusPoint());

        if (BonusPoint() == _switch.Capacity)
        {
            Debug.Log("Bonus Point");
            // Reset all Switch
            _switchContainer.Clear();
            ResetSwitches();
            // _isOn = false;
            // obj.SetMaterial(_isOn);
        }
    }

    private int BonusPoint()
    {
        int point = 0;
        SwitchController[] switchList = _switch.ToArray();
        for (int i = 0; i < switchList.Length; i++)
        {
            if (switchList[i]._isOn)
            {
                point += 1;
            }
        }

        return point;
    }

    private void ResetSwitches()
    {
        SwitchController[] switchList = _switch.ToArray();
        for (int i = 0; i < switchList.Length; i++)
        {
            switchList[i].TurnOnBlink(0, 5);
        }
    }

}
