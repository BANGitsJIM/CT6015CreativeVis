using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassW;
    public WheelCollider rearDriverW, rearPassW;
    public Transform frontDriverT, frontPassT;
    public Transform rearDriverT, rearPassT;
    public float maxSteeringAngle = 30;
    public float motorForce = 50;

    public ButtonPressed stopButton;
    public ButtonPressed goButton;

    private float brake;
    private float drive;

    private void Start()
    {
        //stopButton.OnPointerDown()
    }

    public void GetInput()
    {

       // #if UNITY_EDITOR || UNITY_STANDALONE

              //  m_horizontalInput = Input.GetAxis("Horizontal");
               // m_verticalInput = Input.GetAxis("Vertical");

        //#elif UNITY_ANDROID || UNITY_IOS

        
                Quaternion referenceRotation = Quaternion.identity;
                Quaternion deviceRotation = DeviceRotation.Get();
                Quaternion eliminationOfXY = Quaternion.Inverse(
                    Quaternion.FromToRotation(referenceRotation * Vector3.forward,
                                                deviceRotation * Vector3.forward)
                );
                Quaternion rotationZ = eliminationOfXY * deviceRotation;
                float roll = rotationZ.eulerAngles.z;

                if (roll > 0 && roll < 90)
                {
                    m_horizontalInput = -((roll - 10) / (90 - 10));
                }
                else if (roll > 270 && roll < 360)
                {
                    m_horizontalInput = (roll - 350) / (270 - 350);
                }

                 if(stopButton.Pressed())
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
        
                
//#endif

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
    }


}