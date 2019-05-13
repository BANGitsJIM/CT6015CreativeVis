using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float m_horizontalInput;
    public float m_verticalInput;
    public float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassW;
    public WheelCollider rearDriverW, rearPassW;
    public Transform frontDriverT, frontPassT;
    public Transform rearDriverT, rearPassT;
    public float maxSteeringAngle = 30;
    public float motorForce = 50;
    public float Speed;

    [Range(0.5f, 1.5f)]
    public float enginePitch = 0.5f;

    public ButtonPressed stopButton;
    public ButtonPressed goButton;

    public float brake = 0;
    public float drive = 0;

    public void GetInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");

#endif

#if UNITY_ANDROID || UNITY_IOS

        float roll = Input.acceleration.x * 2;
        //Debug.Log(roll);

        m_horizontalInput = roll;

        if (stopButton.Pressed())
        {
            brake = -1f;
        }
        else
        {
            brake = 0f;
        }

        if (goButton.Pressed())
        {
            drive = 1f;
        }
        else
        {
            drive = 0f;
        }

        m_verticalInput = brake + drive;
        //m_horizontalInput = Input.GetAxis("Horizontal");

#endif
    }

    private void OnBrakePressed(bool pressed)
    {
    }

    private void OnDrivePressed(bool pressed)
    {
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
        CheckMute();
        UpdatePitch();
    }

    private void CheckMute() //Controls engine sound if audio manager is muted
    {
        AudioSource pitch = this.gameObject.GetComponent<AudioSource>();
        AudioManager audioManager = GameObject.FindWithTag("music").GetComponent<AudioManager>();

        if (audioManager.mute == true)
        {
            pitch.mute = true;
        }
        else
        {
            pitch.mute = false;
        }
    }

    private void UpdatePitch()
    {
        Rigidbody car = this.gameObject.GetComponent<Rigidbody>();
        //enginePitch = car.velocity.sqrMagnitude;
        Speed = car.velocity.magnitude;
        //enginePitch = (Speed - 0.5f) / (1.5f - 0.5f);
        enginePitch = Mathf.Lerp(0.5f, 1.5f, (Speed / 4));

        if (enginePitch > 1.5f)
        {
            enginePitch = 1.5f;
        }
        else if (enginePitch < 0.5f)
        {
            enginePitch = 0.5f;
        }
        //enginePitch = Speed;
        AudioSource engineSound = this.gameObject.GetComponent<AudioSource>();
        engineSound.pitch = enginePitch;
    }
}