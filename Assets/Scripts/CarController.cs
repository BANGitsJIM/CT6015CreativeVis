﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteeringAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        //FWD
        //frontDriverW.motorTorque = m_verticalInput * motorForce;
        //frontPassW.motorTorque = m_verticalInput * motorForce;
        //RWD
        rearDriverW.motorTorque = m_verticalInput * motorForce;
        rearPassW.motorTorque = m_verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassW, frontPassT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassW, rearPassT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassW;
    public WheelCollider rearDriverW, rearPassW;
    public Transform frontDriverT, frontPassT;
    public Transform rearDriverT, rearPassT;
    public float maxSteeringAngle = 30;
    public float motorForce = 50;
}