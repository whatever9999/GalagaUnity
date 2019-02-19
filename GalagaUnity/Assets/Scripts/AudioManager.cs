using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound backgroundMusic;
    public Sound[] explosions;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in explosions)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        backgroundMusic.source = gameObject.AddComponent<AudioSource>();
        backgroundMusic.source.clip = backgroundMusic.clip;
        backgroundMusic.source.volume = backgroundMusic.volume;
        backgroundMusic.source.pitch = backgroundMusic.pitch;
        backgroundMusic.source.loop = backgroundMusic.loop;
    }

    private void Start()
    {
        backgroundMusic.source.Play();
    }

    public void Explosion()
    {
        int rand = (int)UnityEngine.Random.Range(0, explosions.Length);

        AudioSource explosion = explosions[rand].source;
        explosion.Play();
    }
}

[Serializable]
public class Sound
{
    public bool loop;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}