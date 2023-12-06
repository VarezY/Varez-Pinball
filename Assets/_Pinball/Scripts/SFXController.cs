using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;
    void Start()
    {
        Destroy(gameObject, _timeDestroy);
    }

}
