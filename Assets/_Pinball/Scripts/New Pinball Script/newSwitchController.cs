using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    
    [SerializeField] 
    private Material onMaterial;

    [SerializeField] 
    private Material offMaterial;

    [SerializeField] private int blinkDelay = 5;
    [SerializeField] private int id;
    
    private Renderer _renderer;
    private SwitchState _switchState;
    private int _bonusScore;

    [Header("Debug")] public bool isOn;

    public int GETId()
    {
        return id;
    }

    private void Start()
    {
        GameEvents.Instantiate.ONToogleSwitch += ToogleSwitch;
        
        _renderer = GetComponent<Renderer>();
        _renderer.material = offMaterial;
        isOn = false;
        
        TurnOnBlink(blinkDelay, 5);
    }

    private void OnDestroy()
    {
        GameEvents.Instantiate.ONToogleSwitch -= ToogleSwitch;
    }

    private void ToogleSwitch(int obj)
    {
        if (obj == id)
        {
            ToggleSwitch();
        }
    }

    private void ToggleSwitch()
    {
        if (_switchState == SwitchState.On)
        {
            SetMaterial(false);
        }
        else
        {
            SetMaterial(true);
        }
    }
    
    private void SetMaterial(bool active)
    {
        if (active)
        {
            _switchState = SwitchState.On;
            StopAllCoroutines();
            _renderer.material = onMaterial;
        }
        else
        {
            _switchState = SwitchState.Off;
            _renderer.material = offMaterial;
        }
    }

    #region BLINK SWITCH
    public void TurnOnBlink(int timeDelay, int numBlink)
    {
        _switchState = SwitchState.Off;
        _renderer.material = offMaterial;
        StartCoroutine(BlinkTimerStart(timeDelay, numBlink));
    }

    private IEnumerator BlinkTimerStart(int delayTime, int blinkTime)
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(Blink(blinkTime));
    }
    
    private IEnumerator Blink(int times)
    {
        // set statenya menjadi blink dulu sebelum mulai proses
        _switchState = SwitchState.Blink;

        // mulai proses blink tanpa mengubah state lagi
        for (int i = 0; i < times; i++)
        {
            _renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            _renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
	
        // set menjadi off kembali setelah proses blink
        _switchState = SwitchState.Off;
        // StartCoroutine(BlinkTimerStart(_blinkDelay, 5));

    }
    #endregion
    
}
