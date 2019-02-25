﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void LoadNewScene(string sceneName)
    {
        //Load this scene
        SceneManager.LoadScene(sceneName);
    }


}
