using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public KeyCode input;
    
    public float maxForce;
    public float maxTimeHold;
    private bool _isHold;

    private void Start()
    {
        _isHold = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            ReadInput(collision.collider);
        }
    }
	
    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !_isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }
    
    private IEnumerator StartHold(Collider collider)
    {
        _isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        _isHold = false;
    }
}
