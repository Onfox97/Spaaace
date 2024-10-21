using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider slider_music;
    public Slider slider_sound;

    public Toggle toggle_postProcessing;
    public AudioSource audio_music;

    void Start()
    {
        audio_music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("musicValume"))
        {
            slider_music.value = PlayerPrefs.GetFloat("musicValume");
        }
        if(PlayerPrefs.HasKey("soundValume"))
        {
            slider_sound.value = PlayerPrefs.GetFloat("soundValume");
        }
        if(PlayerPrefs.HasKey("prostProcessing"))
        {
            int i = PlayerPrefs.GetInt("prostProcessing");
            if(i == 1) toggle_postProcessing.isOn = true;
            else toggle_postProcessing.isOn = false;
        }
        
    }
    public void Music_change()
    {
        float valume_music = slider_music.value;

        audio_music.volume = valume_music;
        
        PlayerPrefs.SetFloat("musicValume",valume_music);
    }
    public void Sound_change()
    {
        float valume_sound = slider_sound.value;
        
        PlayerPrefs.SetFloat("soundValume",valume_sound);
    }
    public void postProccesing_Change()
    {
        if(toggle_postProcessing.isOn) PlayerPrefs.SetInt("prostProcessing",1);
        else PlayerPrefs.SetInt("prostProcessing",0);
    }
}
