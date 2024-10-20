using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    public UnityEvent on_death;
    public int health;
    public AudioSource audio_hit;

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0) Die();
    }
    public void Die()
    {
        on_death.Invoke();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        int damage = (int)other.relativeVelocity.magnitude * 4;

        Damage(damage);

        if(audio_hit != null) audio_hit.Play();
    }
}
