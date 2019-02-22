using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarSmall : MonoBehaviour
{
    public float threshold;

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(6, 0, -8);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}