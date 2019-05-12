using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private ButtonPressed goButton;
    private ButtonPressed stopButton;

    private void Start()
    {
        //Target Game Buttons if they exist at the time
        if (GameObject.FindGameObjectsWithTag("GoBtn").Length == 1)
        {
            goButton = GameObject.FindWithTag("GoBtn").GetComponent<ButtonPressed>();
        }
        if (GameObject.FindGameObjectsWithTag("StopBtn").Length == 1)
        {
            stopButton = GameObject.FindWithTag("StopBtn").GetComponent<ButtonPressed>();
        }
    }

    public void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed + Time.deltaTime);
    }

    public void MoveToTarget()
    {
        //Reverse Camera if "Fire1" is Pressed
        if ((Input.GetButton("Fire2")))
        {
            if ((GameObject.FindGameObjectsWithTag("GoBtn").Length == 1))
            {
                if ((goButton.Pressed())) return; //If go button is pressed return.
            }
            if ((GameObject.FindGameObjectsWithTag("StopBtn").Length == 1))
            {
                if ((stopButton.Pressed())) return; //If stop button is pressed return.
            }

            Vector3 _targetPos = objectToFollow.position +
                                objectToFollow.forward * -offset.z +
                                objectToFollow.right * offset.x +
                                objectToFollow.up * offset.y;

            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed + Time.deltaTime); //Reverse the camera
        }
        else //If the stop buttons don't exist
        {
            Vector3 _targetPos = objectToFollow.position +
                             objectToFollow.forward * offset.z +
                             objectToFollow.right * offset.x +
                             objectToFollow.up * offset.y;

            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed + Time.deltaTime); //Follow the vehicle
        }
    }

    public void FixedUpdate()
    {
        buttonCheck();

        //If mouse is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
        else //If it is not pressed move camera to follow target
        {
            LookAtTarget();
            MoveToTarget();
        }

        if ((GameObject.FindGameObjectsWithTag("GoBtn").Length == 1))
        {
            if ((!Input.GetMouseButton(0)) || (goButton.Pressed())) return; // if mouse or go button pressed return
        }

        if ((GameObject.FindGameObjectsWithTag("StopBtn").Length == 1))
        {
            if ((!Input.GetMouseButton(0)) || (stopButton.Pressed())) return; // if mouse or stop button pressed return
        }

        if ((GameObject.FindGameObjectsWithTag("GoBtn").Length == 1) && (GameObject.FindGameObjectsWithTag("StopBtn").Length == 1))
        {
            if ((!Input.GetMouseButton(0)) || (goButton.Pressed()) || (stopButton.Pressed())) return; //If mouse is not pressed, or either stop or go button end
        }
        else
        {
            if ((!Input.GetMouseButton(0))) return; //If mouse is not pressed, end
        }

        //Otherwise update the camera position via mouse position.
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }

    private void buttonCheck()
    {
        //Target Game Buttons if they exist at the time
        if (GameObject.FindGameObjectsWithTag("GoBtn").Length == 1)
        {
            goButton = GameObject.FindWithTag("GoBtn").GetComponent<ButtonPressed>();
        }
        if (GameObject.FindGameObjectsWithTag("StopBtn").Length == 1)
        {
            stopButton = GameObject.FindWithTag("StopBtn").GetComponent<ButtonPressed>();
        }
    }
}