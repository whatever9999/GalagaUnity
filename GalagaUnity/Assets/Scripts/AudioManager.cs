using UnityEngine.Audio;
using UnityEngine;
using System;

/**
 * Allocates audio sources to any provided Sounds
 * Plays clips
 * */
public class AudioManager : MonoBehaviour
{
    public Sound backgroundMusic;
    public Sound[] explosions;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        //Allocate audio sources to each sound provided in the inspector
        foreach (Sound s in explosions)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }

        //Allocate an audio source to the background music
        backgroundMusic.source = gameObject.AddComponent<AudioSource>();
        backgroundMusic.source.clip = backgroundMusic.clip;
        backgroundMusic.source.volume = backgroundMusic.volume;
        backgroundMusic.source.pitch = backgroundMusic.pitch;
        backgroundMusic.source.loop = backgroundMusic.loop;
        backgroundMusic.source.outputAudioMixerGroup = backgroundMusic.audioMixerGroup;
    }

    private void Start()
    {
        backgroundMusic.source.Play();
    }

    public void Explosion()
    {
        //Generate a random number between 0 and the number of explosions
        int rand = (int)UnityEngine.Random.Range(0, explosions.Length);

        //Play the sound with the index
        AudioSource explosion = explosions[rand].source;
        explosion.Play();
    }
}

[Serializable]
public class Sound
{
    public AudioClip clip;

    //if the sound clip loops or not
    public bool loop;

    //The mixer allocated to the clip
    public AudioMixerGroup audioMixerGroup;
    
    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}