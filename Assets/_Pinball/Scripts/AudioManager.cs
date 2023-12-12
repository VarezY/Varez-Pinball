using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource bgmAudioSource;
    [SerializeField] private GameObject sfxSwitch;
    [SerializeField] private GameObject sfxBumper;
    
    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlayBumperSFX(Vector3 spawnPos)
    {
        Instantiate(sfxBumper, spawnPos, Quaternion.identity);
    }
    
    public void PlaySwitchSFX(Vector3 spawnPos)
    {
        Instantiate(sfxSwitch, spawnPos, Quaternion.identity);
    }
}
