using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSwitchManager : MonoBehaviour
{
    [Header("SFX & VFX")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private VFXManager _vfxManager;
   
    [Header("Switches")]
    [SerializeField] private List<newSwitchController> _switch;

    private newSwitchController controller;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instantiate.onToogleSwitch += SwitchEnter;
        GameEvents.Instantiate.onToogleSwitch += PlaySfxSwitch;
        GameEvents.Instantiate.onToogleSwitch += PlayVfxSwitch;
    }

    private void OnDestroy()
    {
        GameEvents.Instantiate.onToogleSwitch -= SwitchEnter;
        GameEvents.Instantiate.onToogleSwitch -= PlaySfxSwitch;
        GameEvents.Instantiate.onToogleSwitch -= PlayVfxSwitch;
    }

    private void SwitchEnter(int obj)
    {
        controller = _switch[obj-1];
        if (obj == controller.GETId())
        {
            controller.isOn = !controller.isOn;
            if (BonusPoint() == (_switch.Capacity))
            {
                Debug.Log("Bonus Point");
            }
        }
    }
    
    private int BonusPoint()
    {
        int point = 0;
        newSwitchController[] switchList = _switch.ToArray();
        for (int i = 0; i < switchList.Length; i++)
        {
            if (switchList[i].isOn)
            {
                point++;
            }
        }
        Debug.Log(point);
        return point;
    }

    #region AUDIO SFX
    private void PlaySfxSwitch(int obj)
    {
        controller = _switch[obj-1];
        _audioManager.PlaySwitchSFX(controller.transform.position);
    }
    #endregion

    #region EFFECT VFX
    private void PlayVfxSwitch(int obj)
    {
        controller = _switch[obj-1];
        _vfxManager.PlaySwitchVFX(controller.transform.position);
    }
    #endregion

    
}
