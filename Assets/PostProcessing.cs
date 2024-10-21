using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessing : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.HasKey("prostProcessing"))
        {
            int i = PlayerPrefs.GetInt("prostProcessing");
            if(i == 0) gameObject.SetActive(false);
        }
    }

}
