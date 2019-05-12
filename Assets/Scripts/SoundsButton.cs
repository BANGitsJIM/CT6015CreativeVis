using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsButton : MonoBehaviour
{
    private AudioManager audioManager;

    public GameObject soundOn;
    public GameObject soundOff;

    private void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found in the scene.!!!");
        }

        if (audioManager.mute == true)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        else if (audioManager.mute == false)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
    }

    public void MuteSounds()
    {
        audioManager.ToggleMute(true);
    }

    public void PlaySounds()
    {
        audioManager.ToggleMute(false);
    }
}