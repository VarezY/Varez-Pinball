using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxSource;
    [SerializeField] private GameObject vfxSwitch;
    [SerializeField] private GameObject vfxBumper;

    public void PlayVFX(Vector3 spawnPosition)
    {
        // spawn vfx pada posisi sesuai parameter
        Instantiate(vfxSource, spawnPosition, Quaternion.identity);
    }

    public void PlayBumperVFX(Vector3 spawnPos)
    {
        Instantiate(vfxBumper, spawnPos, Quaternion.identity);
    }
    
    public void PlaySwitchVFX(Vector3 spawnPos)
    {
        Instantiate(vfxSwitch, spawnPos, Quaternion.identity);
    }
}
