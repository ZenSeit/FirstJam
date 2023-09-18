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
    public AudioClip rollOver;
    public AudioClip switchSound;
    public AudioClip musicBackground;

    public AudioClip jumpSound;
    public AudioClip dieSound;
    public AudioClip transformationSound;
    public AudioClip coinSound;


    public void ClickSound()
    {
        SFXSource.PlayOneShot(clickSound);
    }

    public void SwitchSound()
    {
        SFXSource.PlayOneShot(rollOver);
    }

    public void PlaySFXSound(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void Start()
    {
        musicSource.clip = musicBackground;
        musicSource.Play();
    }
}
