using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructibleController : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool isQuitting = false;
    public string sceneName;
    public bool SpawnOnDeath = true;
    public bool thisSignDestroyed = false;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found in the scene.!!!");
        }
        else
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerDestroyed();
            PreDestroy();
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            LoadMyScene();
            Handheld.Vibrate();
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
        audioManager.PlaySound("WoodBreak");
    }

    private void LoadMyScene()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string currentSceneName = currentScene.name;

        //Retrieve game Object
        GameObject myObject = GameObject.FindWithTag("GameController");

        if (!string.IsNullOrEmpty(sceneName))
        {
            if (!isScene_CurrentlyLoaded(sceneName))
            {
                if (myObject != null)
                {
                    myObject.GetComponent<LoadScene>().AddScene(sceneName);
                }
            }
            else
            {
                return;
            }
        }
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void PreDestroy()
    {
        //Debug.Log("Destroying the object");

        if (!isQuitting)
        {
            GameObject myObject = GameObject.FindWithTag("GameController");

            if (myObject != null)
            {
                SignHandler signHandler = myObject.GetComponent<SignHandler>();

                if ((signHandler != null))
                {
                    //Debug.Log("Generating new object");
                    signHandler.generateObjectOnTerrain();
                }
            }
        }

        Destroy(gameObject);
    }

    //Bool to check if a scene already exists
    private bool isScene_CurrentlyLoaded(string sceneName_no_extention)
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName_no_extention)
            {
                //the scene is already loaded
                return true;
            }
        }

        return false;//scene not currently loaded in the hierarchy
    }

    private void OnDestroy()
    {
        //LoadMyScene();
    }
}