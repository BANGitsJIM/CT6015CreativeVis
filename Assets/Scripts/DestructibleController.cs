using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleController : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool isQuitting = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Building")
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            GameObject myObject = GameObject.FindWithTag("GameController");
            myObject.GetComponent<SignHandler>().generateObjectOnTerrain();
        }
    }
}