using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveScene : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}