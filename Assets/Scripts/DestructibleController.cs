using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleController : MonoBehaviour
{
    public GameObject destroyedVersion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}