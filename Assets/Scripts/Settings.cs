using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider slider_music;
    public Slider slider_sound;

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
}
