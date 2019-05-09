﻿using UnityEngine;

public class DestructibleController : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool isQuitting = false;
    public string sceneName;
    public bool SpawnOnDeath = true;
    public bool thisSignDestroyed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerDestroyed();
            PreDestroy();
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            LoadMyScene();
        }
        if (other.tag == "Building")
        {
            PreDestroy();
        }
    }

    private void PlayerDestroyed()
    {
        //Debug.Log("Player Destroyed This Sign");
        thisSignDestroyed = true;
    }

    private void LoadMyScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            GameObject myObject = GameObject.FindWithTag("GameController");
            myObject.GetComponent<LoadScene>().AddScene(sceneName);
        }
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void PreDestroy()
    {
        Debug.Log("Destroying the object");

        if (!isQuitting)
        {
            GameObject myObject = GameObject.FindWithTag("GameController");

            if (myObject != null)
            {
                SignHandler signHandler = myObject.GetComponent<SignHandler>();

                if ((signHandler != null))
                {
                    Debug.Log("Generating new object");
                    signHandler.generateObjectOnTerrain();
                }
            }
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
    }
}