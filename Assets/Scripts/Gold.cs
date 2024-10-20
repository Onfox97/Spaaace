using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int add_score = 1;
    public LayerMask layerMask_ship;
    public GameObject prefab_sfx;
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position,1.25f,layerMask_ship))
        {
            ScoreSystem.addScore(add_score);
            
            Instantiate(prefab_sfx);
            transform.position += Vector3.one *2000;
        }
    }

}
