using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleController : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject sign;
    private Vector3 pos;
    private Quaternion rot;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        pos = new Vector3(5, 2, -8);
        rot = transform.rotation;
        //Instantiate(sign, pos, rot);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        //Instantiate(sign, pos, rot);
    }
}