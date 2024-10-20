
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("soundValume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("soundValume");
        }
        else PlayerPrefs.SetFloat("soundValume",1f);
    }
}
