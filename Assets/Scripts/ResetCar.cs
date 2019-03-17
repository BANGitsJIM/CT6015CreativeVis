using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    public float threshold;
    public Vector3 ResetPosition;

    private void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = ResetPosition;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public void ResetThisCar()
    {
        transform.position = ResetPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}