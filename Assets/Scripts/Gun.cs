using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gun_barell;
    public GameObject prefab_bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aim();
        if(Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void aim()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition -= (Vector2)transform.position;

        float new_rotation = Mathf.Atan2(mousePosition.y,mousePosition.x)*Mathf.Rad2Deg -90;

        transform.rotation = Quaternion.Euler(0,0,new_rotation);
    }
    void shoot()
    {
        Instantiate(prefab_bullet,gun_barell.position,gun_barell.rotation);
    }
}
