using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    public AudioMixer audioMixer;

    // public AudioMixerGroup MasterAudioMixerGroup;
    // public AudioMixerGroup MusicAudioMixerGroup;
    // public AudioMixerGroup EffectsAudioMixerGroup;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider EffectsSlider;

    void Start()
    {
        // audioMixer = Resources.Load("MainAudioMixer") as AudioMixer;
        // if (!audioMixer)
        //     throw new System.Exception("Failed to load MainAudioMixer");

        // Debug.Log(MasterAudioMixerGroup.name + " == 'Master'");
        // Debug.Log(MusicAudioMixerGroup.name + " == 'Music'");
        // Debug.Log(EffectsAudioMixerGroup.name + " == 'Effects'");



        MasterSlider.onValueChanged.AddListener(OnMasterSliderValueChanged);
        MusicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        EffectsSlider.onValueChanged.AddListener(OnEffectsSliderValueChanged);

    }


    public void OnMasterSliderValueChanged(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }
    public void OnMusicSliderValueChanged(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
    }
    public void OnEffectsSliderValueChanged(float value)
    {
        audioMixer.SetFloat("EffectsVolume", value);
    }
}
