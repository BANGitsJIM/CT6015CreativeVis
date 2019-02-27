using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleController : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool isQuitting = false;
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);

            Debug.Log(sceneName);

            LoadMyScene();

            Destroy(gameObject);
        }
        if (other.tag == "Building")
        {
            Destroy(gameObject);
        }
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

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            GameObject myObject = GameObject.FindWithTag("GameController");
            myObject.GetComponent<SignHandler>().generateObjectOnTerrain();
        }
    }
}