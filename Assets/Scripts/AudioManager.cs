using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip clickSound;
    public AudioClip switchSound;
    public AudioClip musicBackground;

    public void ClickSound()
    {
        SFXSource.PlayOneShot(clickSound);
    }

    public void SwitchSound()
    {
        SFXSource.PlayOneShot(switchSound);
    }

    private void Start()
    {
        musicSource.clip = musicBackground;
        musicSource.Play();
    }
}
