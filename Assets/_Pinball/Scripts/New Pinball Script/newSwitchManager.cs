using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class newSwitchManager : MonoBehaviour
{
    [Header("SFX & VFX")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private VFXManager vfxManager;

    [Header("Switches")] 
    [SerializeField] private int point;
    [SerializeField] private int bonusPoint;
    
    private List<newSwitchController> @switch;
    private newSwitchController _controller;

    // Start is called before the first frame update
    void Start()
    {
        @switch = GetComponentsInChildren<newSwitchController>().ToList();
        
        GameEvents.Instantiate.ONToogleSwitch += SwitchEnter;
        GameEvents.Instantiate.ONToogleSwitch += PlaySfxSwitch;
        GameEvents.Instantiate.ONToogleSwitch += PlayVfxSwitch;
    }

    private void OnDestroy()
    {
        GameEvents.Instantiate.ONToogleSwitch -= SwitchEnter;
        GameEvents.Instantiate.ONToogleSwitch -= PlaySfxSwitch;
        GameEvents.Instantiate.ONToogleSwitch -= PlayVfxSwitch;
    }

    private void SwitchEnter(int obj)
    {
        _controller = @switch[obj-1];
        if (obj == _controller.GETId())
        {
            _controller.isOn = !_controller.isOn;
            if (BonusPoint() == (@switch.Capacity))
            {
                Debug.Log("Bonus Point");
                GameEvents.Instantiate.UpdateScore(bonusPoint);
                BlinkBonus();
            }
            else
            {
                Debug.Log("Add 1 point!");
                GameEvents.Instantiate.UpdateScore(point);
            }
        }
    }

    #region BONUS POINT

    private int BonusPoint()
    {
        int point = 0;
        newSwitchController[] switchList = @switch.ToArray();
        for (int i = 0; i < switchList.Length; i++)
        {
            if (switchList[i].isOn)
            {
                point++;
            }
        }
        return point;
    }

    private void BlinkBonus()
    {
        foreach (newSwitchController switchController in @switch)
        {
            switchController.TurnOnBlink(0, 8);
        }
    }

    #endregion
   

    #region AUDIO SFX
    private void PlaySfxSwitch(int obj)
    {
        _controller = @switch[obj-1];
        audioManager.PlaySwitchSFX(_controller.transform.position);
    }
    #endregion

    #region EFFECT VFX
    private void PlayVfxSwitch(int obj)
    {
        _controller = @switch[obj-1];
        vfxManager.PlaySwitchVFX(_controller.transform.position);
    }
    #endregion

    
}
