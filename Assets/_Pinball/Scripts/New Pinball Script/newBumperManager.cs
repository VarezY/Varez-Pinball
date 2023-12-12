using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBumperManager : MonoBehaviour
{
    [SerializeField] private int point;
    
    [Header("SFX & VFX")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private VFXManager vfxManager;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instantiate.ONBumpBumper += AddPoint;
        GameEvents.Instantiate.ONBumpBumper += PlayVFX;
        GameEvents.Instantiate.ONBumpBumper += PlaySfx;
    }

    private void AddPoint(Transform obj)
    {
        GameEvents.Instantiate.UpdateScore(point);
    }

    private void PlaySfx(Transform obj)
    {
        audioManager.PlayBumperSFX(obj.position);
    }

    private void PlayVFX(Transform obj)
    {
        vfxManager.PlayBumperVFX(obj.position);
    }

    
}
