using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float shot_delay;
    public Transform transform_barell;
    public GameObject prefab_rocket;
    float rotation_current;
    float delay_time;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        delay_time = shot_delay;
    }

    // Update is called once per frame
    void Update()
    {
        if(target !=null)rotateAtTarget();
        if(delay_time <=0)
        {
            shoot();
            delay_time = shot_delay;
        }
        delay_time -= Time.deltaTime;
    }
    void rotateAtTarget()
    {
        Vector3 relative_target_position;
        relative_target_position = target.position - transform.position;

        float wanted_rotation = Mathf.Atan2(relative_target_position.y,relative_target_position.x)*Mathf.Rad2Deg-90;
        rotation_current = Mathf.LerpAngle(rotation_current,wanted_rotation,speed*Time.deltaTime);

        transform.rotation = Quaternion.Euler(0,0,rotation_current);
    }
    void shoot()
    {
        Instantiate(prefab_rocket,transform_barell.position,transform.localRotation);
    }
    public void death()
    {
        transform.position = Vector3.one * 99999;
    }
}
