using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public bool loop = false;
    public AudioClip clip;
    public bool resetOnSceneChange = true;

    [Range(0f, 1f)]
    public float volume = 0.7f;

    [Range(0.5f, 2f)]
    public float pitch = 1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.Play();
    }

    public void Mute()
    {
        source.mute = true;
    }

    public void Unmute()
    {
        source.mute = false;
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool mute = false;

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            //Debug.LogError("More than one AudioManager in the scene.");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform); //Attaches sounds to this GameObject
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

        PlaySound("Music");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        //no sounds with _name
        Debug.LogWarning("AudioManager, Sound could not be found: " + _name);
    }

    public void Update()
    {
        /* if (mute == true)
         {
             for (int i = 0; i < sounds.Length; i++)
             {
                 sounds[i].Mute();
             }
         }
         else
         {
             for (int i = 0; i < sounds.Length; i++)
             {
                 sounds[i].Unmute();
             }
         }*/
    }

    public void ToggleMute(bool _muted)
    {
        if (_muted == true)
        {
            this.mute = true;

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].Mute();
            }
        }
        else
        {
            this.mute = false;

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].Unmute();
            }
        }
    }
}