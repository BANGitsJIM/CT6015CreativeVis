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

    public void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed + Time.deltaTime);
    }

    public void MoveToTarget()
    {
        //Reverse Camera if "Fire1" is Pressed
        if (Input.GetButton("Fire2"))
        {
            Vector3 _targetPos = objectToFollow.position +
                             objectToFollow.forward * -offset.z +
                             objectToFollow.right * offset.x +
                             objectToFollow.up * offset.y;

            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed + Time.deltaTime);
        }
        else
        {
            Vector3 _targetPos = objectToFollow.position +
                             objectToFollow.forward * offset.z +
                             objectToFollow.right * offset.x +
                             objectToFollow.up * offset.y;

            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed + Time.deltaTime);
        }
    }

    public void FixedUpdate()
    {
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

        //If mouse is not pressed, end
        if (!Input.GetMouseButton(0)) return;

        //Otherwise update the camera position via mouse position.
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }
}