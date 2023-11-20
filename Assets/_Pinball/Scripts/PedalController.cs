using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalController : MonoBehaviour
{
    [SerializeField] private HingeJoint _RightPedal, _LeftPedal;

    public GameObject _RightAnchor, _LeftAnchor;

    [Header("Inputs")]
    public KeyCode input;
    public KeyCode leftInput; 
    public KeyCode rightInput;

    [Header("Hinge Properties")]
    public float springPower;
    [Range(-100f, 100f)]
    public float minAnchorRange;
    [Range(-100f, 100f)]
    public float maxAnchorRange;
    [Range(0, 100f)]
    public float damper;

    private JointSpring rightJointSpring, leftJoinSpring;
    private float targetPressed;
    private float targetRelease;


    // Start is called before the first frame update
    void Start()
    {
        _RightPedal.anchor = new Vector3(_RightAnchor.transform.localPosition.x, _RightPedal.anchor.y, _RightPedal.anchor.z);
        _LeftPedal.anchor = new Vector3(_LeftAnchor.transform.localPosition.x, _LeftPedal.anchor.y, _LeftPedal.anchor.z);

        rightJointSpring = _RightPedal.spring;
        rightJointSpring.damper = damper;
        rightJointSpring.spring = springPower;
        _RightPedal.spring = rightJointSpring;

        leftJoinSpring = _LeftPedal.spring;
        leftJoinSpring.damper = damper;
        leftJoinSpring.spring = springPower;
        _LeftPedal.spring = rightJointSpring;

        targetPressed = maxAnchorRange;
        targetRelease = minAnchorRange;

        ConfigurePedals(_RightPedal, minAnchorRange, maxAnchorRange);
        ConfigurePedals(_LeftPedal, minAnchorRange, maxAnchorRange);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ConfigurePedals(HingeJoint _hingeSpring, float minAnchor, float maxAnchor)
    {
        JointSpring s;
        JointLimits l;

        /*Spring Target Position Configuration*/
        s = _hingeSpring.spring;
        s.targetPosition = minAnchor;
        _hingeSpring.spring = s;

        /*Limits Configuration*/
        l = _hingeSpring.limits;
        l.min = minAnchor;
        l.max = maxAnchor;
        _hingeSpring.limits = l;


    }
     
    private void ReadInput()
    {

        if (Input.GetKey(input) || (Input.GetKey(leftInput) && Input.GetKey(rightInput)))
        {
            rightJointSpring.targetPosition = targetPressed;
            leftJoinSpring.targetPosition = targetPressed;
        }
        else if (Input.GetKey(rightInput))
        {
            rightJointSpring.targetPosition = targetPressed;
        }
        else if (Input.GetKey(leftInput))
        {
            leftJoinSpring.targetPosition = targetPressed;
        }
        else
        {
            rightJointSpring.targetPosition = targetRelease;
            leftJoinSpring.targetPosition = targetRelease;
        }

        _RightPedal.spring = rightJointSpring;
        _LeftPedal.spring = leftJoinSpring;
    }
}
