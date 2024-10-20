using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [Header("SHIP SETTING")]
    public float rocket_acceleration;   //síla akcelerace rakety
    public float rocket_rotation_acceleration;
    public float maximal_rocket_speed;  //definuje maximální rychlost rakety při které může akcelerovat
    public float fuel_maximal;
    public float fuel_consuption;


    [Header("INPUT")]
    public KeyCode key_rocket_accelerate;   
    public KeyCode key_rocket_turn_left;
    public KeyCode key_rocket_turn_right;

    public Health health;

    [Header("EFFECTS")]
    public GameObject prefab_shipExplosion;
    public ParticleSystem particle_foward;
    public ParticleSystem particle_left;
    public ParticleSystem particle_right;

    public AudioSource audio_thruster_foward;
    public AudioSource audio_thruster_left;
    public AudioSource audio_thruster_right;



    public static float fuel_current;
    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        fuel_current = fuel_maximal;

        
    }

    void Update()
    {
        RocketControll();

        //fuel check
        if(fuel_current < 0) 
        {
            health.Die();
            Die();
        }
        if(fuel_current > fuel_maximal) fuel_current = fuel_maximal;

        
    }
    void RocketControll()
    {
        //Akcelerace
        if(Input.GetKey(key_rocket_accelerate))
        {
            RocketAccelerate();
            if(!particle_foward.isPlaying)  particle_foward.Play();
            if(!audio_thruster_foward.isPlaying) audio_thruster_foward.Play();
        }
        else 
        {
            particle_foward.Stop();
            audio_thruster_foward.Stop();
        }

        //Zatáčení
        if(Input.GetKey(key_rocket_turn_left))
        {
            RocketTurn(1);
            if(!particle_left.isPlaying)    particle_left.Play();
            if(!audio_thruster_left.isPlaying) audio_thruster_left.Play();
        }
        else 
        {
            particle_left.Stop();
            audio_thruster_left.Stop();
        }

        if(Input.GetKey(key_rocket_turn_right))
        {
            RocketTurn(-1);
            if(!particle_right.isPlaying)   particle_right.Play();
             if(!audio_thruster_right.isPlaying) audio_thruster_right.Play();
            
        }
        else 
        {
            particle_right.Stop();
            audio_thruster_right.Stop();
        }
    }
    void RocketAccelerate()
    {
        if(rig.velocity.magnitude <= maximal_rocket_speed)
        {
            fuel_current -= fuel_consuption * Time.deltaTime;

            rig.AddForce(transform.up*rocket_acceleration * Time.deltaTime);
        }
    }
    void RocketTurn(int direction)
    {
        fuel_current -= fuel_consuption * Time.deltaTime/3;

        rig.AddTorque(rocket_rotation_acceleration * direction * Time.deltaTime);
    }
    public void Die()
    {
        Instantiate(prefab_shipExplosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

}
