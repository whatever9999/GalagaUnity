using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    GameManager gm = GameManager.instance;

    public void StartButton()
    {
        gm.Game();
    }

    public void QuitButton()
    {
        gm.QuitGame();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
