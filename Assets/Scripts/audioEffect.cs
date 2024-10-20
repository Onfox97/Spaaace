using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioEffect : MonoBehaviour
{
    public bool pitch_isRandom;
    public float pitch_min;
    public float pitch_max;
    public AudioSource audio_source;
    void Start()
    {
        if(pitch_isRandom)
        {
            float pitch = Random.Range(pitch_min,pitch_max);

            audio_source.pitch = pitch;
        }
        
        Destroy(gameObject,audio_source.clip.length);
    }

}
