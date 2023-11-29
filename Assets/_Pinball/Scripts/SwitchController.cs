using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    
    [SerializeField] 
    private Material _onMaterial;

    [SerializeField] 
    private Material _offMaterial;

    [SerializeField] private int _blinkDelay = 5;
    
    public bool _isOn;
    private Renderer _renderer;
    private SwitchState _switchState;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = _offMaterial;

        StartCoroutine(BlinkTimerStart(_blinkDelay));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pinball"))
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
            _renderer.material = _onMaterial;
        }
        else
        {
            _switchState = SwitchState.Off;
            _renderer.material = _offMaterial;
        }
    }
    
    private IEnumerator BlinkTimerStart(int time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
    
    private IEnumerator Blink(int times)
    {
        // set statenya menjadi blink dulu sebelum mulai proses
        _switchState = SwitchState.Blink;

        // mulai proses blink tanpa mengubah state lagi
        for (int i = 0; i < times; i++)
        {
            _renderer.material = _onMaterial;
            yield return new WaitForSeconds(0.5f);
            _renderer.material = _offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
	
        // set menjadi off kembali setelah proses blink
        _switchState = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(_blinkDelay));

    }
}
