using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public int add_fuel = 20;
    public LayerMask layerMask_ship;
    public GameObject prefab_sfx;
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position,0.85f,layerMask_ship))
        {
            RocketController.fuel_current += add_fuel;
            
            Instantiate(prefab_sfx);
            
            transform.position += Vector3.one *2000;
        }
    }
}
