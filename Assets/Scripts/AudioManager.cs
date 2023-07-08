using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Odpowiada za zarz¹dzanie muzyk¹


----------------------------------------------------------------------------------------------------------- */

public class AudioManager : MonoBehaviour
    {

        public AudioSource[] Audios;
        public AudioMixer mixer;
        public Slider sfxSlider, musicSlider;
        const string MIXER_SFX = "SFXVolume";
        const string MIXER_MUSIC = "MusicVolume";


    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(MIXER_MUSIC);
        sfxSlider.value = PlayerPrefs.GetFloat (MIXER_SFX);
    }
    public void Awake()
        {

            sfxSlider.onValueChanged.AddListener(SetSFXValume);
            musicSlider.onValueChanged.AddListener(SetMusicValume);
        }

        private void SetMusicValume(float value)
        {
            mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
         

        }
        private void SetSFXValume(float value)
        {
            mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
          

        }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MIXER_MUSIC, musicSlider.value);
        PlayerPrefs.SetFloat(MIXER_SFX, sfxSlider.value);
    }

}

