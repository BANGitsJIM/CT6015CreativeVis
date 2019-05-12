using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    private static GameObject instance;

    private void Start()
    {
        /* GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

         if (objs.Length > 1)
         {
             Destroy(this.gameObject);
         }*/

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}