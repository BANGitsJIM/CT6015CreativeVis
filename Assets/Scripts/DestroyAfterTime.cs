using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float forceTime;

    // Start is called before the first frame update
    void Start()
    {
        //If a forcedTime has been given, destroy objects after time set.
        if (forceTime != 0)
        {
            Destroy(gameObject, forceTime);
        }
        else
        {
            float lifetime = Random.Range(0, 6);
            Destroy(gameObject, lifetime);
        }
    }
}