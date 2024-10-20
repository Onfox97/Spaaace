using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform missile_target;
    public float rotation_speed = 1;
    public float missile_speed = 10;
    public float wobble_speed = 20;
    public float wobble_strenght = 2;
    public float test_missile_forceSpeed;
    public float fuel = 10;
    public GameObject prefab_explosion;
    float rotation_current;
    Rigidbody2D rig;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();  
        missile_target = GameObject.FindGameObjectWithTag("Player").transform;
          
    }

    // Update is called once per frame
    void Update()
    {
        fuel -= Time.deltaTime;
        if(missile_target != null&&fuel>=0) rotateAtTarget();
        moveMissile();

    }
    void rotateAtTarget()
    {
        Vector3 relative_target_position;
        
        relative_target_position = missile_target.position - transform.position;

        float wobble = (Mathf.Sin(Time.time*wobble_speed)-0.5f)*wobble_strenght;
        float wanted_rotation = Mathf.Atan2(relative_target_position.y,relative_target_position.x)*Mathf.Rad2Deg-90;
        rotation_current = Mathf.LerpAngle(rotation_current,wanted_rotation,rotation_speed*Time.deltaTime )+wobble;

        transform.rotation = Quaternion.Euler(0,0,rotation_current);
    }
    void moveMissile()
    {
        //rig.velocity = transform.up* missile_speed;
        rig.AddForce(transform.up * test_missile_forceSpeed*Time.deltaTime);

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(prefab_explosion,transform.position,quaternion.identity);
        Destroy(gameObject);
    }
}
