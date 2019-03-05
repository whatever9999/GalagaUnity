using UnityEngine;
using UnityEngine.Audio;

/*
 * Volume changes from the settings menu
 * Start and quit button handling
 * */
public class StartMenu : MonoBehaviour
{
    private const string audioMixerVolumeName = "volume";

    public AudioMixer audioMixer;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

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
        audioMixer.SetFloat(audioMixerVolumeName, volume);
    }
}
