using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float asteroid_size_minimal = 1;
    float asteroid_size_maximal = 5f;

    public bool changeScale = true;
    public int death_split_min = 2;
    public int death_split_max = 4;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    public float destroy_size = 0.25f;
    void Start()
    {
        setupAsteroid();
    }
    void setupAsteroid()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int i = Random.Range(0,sprites.Length);
        spriteRenderer.sprite = sprites[i];

        //náhodná velikost
        if(changeScale == true)
        {
            float new_asteroid_scale = Random.Range(asteroid_size_minimal,asteroid_size_maximal);
            transform.localScale = new Vector3(new_asteroid_scale,new_asteroid_scale,new_asteroid_scale);
        }

        //náhodná rotace
        float new_asteroid_rotation = Random.Range(0,359);
        transform.rotation = Quaternion.Euler(0,0,new_asteroid_rotation);
    }
    public void die()
    {
        int rng = Random.Range(death_split_min,death_split_max);
        for(int i =0; i < rng;i++)
        {

            if(transform.localScale.magnitude/rng !< destroy_size)
            {
                GameObject new_asteroid = Instantiate(gameObject,transform.position,transform.rotation,transform.parent);

                new_asteroid.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity;
                new_asteroid.transform.localScale = transform.localScale/rng;
            }
        }
    }
}
