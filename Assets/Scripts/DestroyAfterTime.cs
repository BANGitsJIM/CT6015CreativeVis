using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float lifetime = Random.Range(0, 6);
        Destroy(gameObject, lifetime);
    }
}