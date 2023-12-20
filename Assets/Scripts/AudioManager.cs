using GoogleVR.VideoDemo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [Header("Event Listening")]
    public PlayAudioEventSO FXEvent;
    public PlayAudioEventSO playerFXEvent;
    public PlayAudioEventSO BGMEvent;
    [Header("Component")]
    public AudioSource BGMSource;
    public AudioSource FXSource;
    public AudioSource playerFXSource;
    public AudioMixer mixer;
    private void OnEnable()
    {
        FXEvent.OnEventRaised += OnFXEvent;
        BGMEvent.OnEventRaised += OnBGMEvent;
        playerFXEvent.OnEventRaised += OnPlayerFXEvent;
    }

    
    private void OnDisable()
    {
        FXEvent.OnEventRaised -= OnFXEvent;
        BGMEvent.OnEventRaised -= OnBGMEvent;
        playerFXEvent.OnEventRaised -= OnPlayerFXEvent;
    }

    private void OnBGMEvent(AudioClip clip)
    {
        BGMSource.clip = clip;
        BGMSource.Play();
    }

    private void OnFXEvent(AudioClip clip)
    {
        FXSource.clip = clip;
        FXSource.Play();
    }

    private void OnPlayerFXEvent(AudioClip clip)
    {
        playerFXSource.clip = clip;
        playerFXSource.Play();
    }

}
