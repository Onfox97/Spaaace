using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public bool musicDuringGameplay;
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Music").Length !=1) Destroy(gameObject);
        if(PlayerPrefs.HasKey("musicValume"))
        {
            source.volume = PlayerPrefs.GetFloat("musicValume");
        }
        else PlayerPrefs.SetFloat("musicValume",0.5f);
        
        if(musicDuringGameplay) DontDestroyOnLoad(gameObject);
    }
}
