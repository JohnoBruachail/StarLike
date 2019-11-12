using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectsMixer;

    float musicSlider;
    float effectsSlider;

    public void Start(){

        musicSlider     = 0.5f;
        effectsSlider   = 0.5f;
    }

    public void SetMusicLevel(float sliderValue){

        musicSlider = sliderValue;

        //represents the slider value as a logarithm to the base of ten then multiplies it by 20
        //takes the slider value and converts it into a value between -80 and 0 on a logmarithmic scale
        musicMixer.SetFloat ("MusicVol", Mathf.Log10(musicSlider) * 20);
    }

    public void SetEffectsLevel(float sliderValue){

        effectsSlider = sliderValue;

        //represents the slider value as a logarithm to the base of ten then multiplies it by 20
        //takes the slider value and converts it into a value between -80 and 0 on a logmarithmic scale
        effectsMixer.SetFloat ("EffectsVol", Mathf.Log10(effectsSlider) * 20);
    }
}
