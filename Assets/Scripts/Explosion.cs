using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosion_strenght;
    public int explosion_damage;
    public float explosion_range;
    public float audio_minPith;
    public float audio_maxPitch;
    public AudioSource audio_explosion;
    void Start()
    {
        explode();
    }
    void explode()
    {
        Collider2D[] hit;
        hit = Physics2D.OverlapCircleAll(transform.position,explosion_range);

        foreach(Collider2D coll in hit)
        {
            float distance = Vector2.Distance(coll.ClosestPoint(transform.position),(Vector2)transform.position)/explosion_range;

            Rigidbody2D rig = coll.attachedRigidbody;
            Health health = coll.GetComponent<Health>();

            if(rig != null)
            {
                Vector3 force_direction = coll.transform.position - transform.position;
                rig.AddForce(force_direction * explosion_strenght * distance);
            }
            if(health != null)
            {
                health.Damage((int)(distance * explosion_damage));
            }
        }

        float pitch = Random.Range(audio_minPith,audio_maxPitch);

        audio_explosion.pitch = pitch;
    }
    void OnDrawGizmos()
    {
        for(int i = 3; i>0 ;i--)
        {
            Gizmos.DrawWireSphere(transform.position,explosion_range/i);
        }
    }


}
