
using System.Collections.Generic;
using UnityEngine;

public class EnviromentGenerator : MonoBehaviour
{
    public EnviromentObject[] Objects;
    public int reach;//Rozsah generace objeků
    public int maxObjectLimit;
    public Transform objects_parent;


    void Start()
    {
        populateEnviroment();
    
    }

    // Update is called once per frame
    void Update()
    {
        checkObjectDistance();
    }

    void checkObjectDistance()
    {
        foreach(Transform objectTransform in objects_parent)
        {
            GameObject checkObject = objectTransform.gameObject;
            Vector2 objectPosition = checkObject.transform.position;
            objectPosition -=  (Vector2)transform.position;

            if(objectPosition.x > reach )
            {
                unloadObject(checkObject);

                float newObjectPoosX = reach*-1;
                float newObjectPoosY = Random.Range(reach*-1,reach);

                Vector2 newObjectPoos = new Vector2(newObjectPoosX,newObjectPoosY);
                newObjectPoos += (Vector2)transform.position;

                loadNewObject(newObjectPoos);
            }
            else if(objectPosition.x < reach *-1)
            {
                unloadObject(checkObject);
                float newObjectPoosX = reach;
                float newObjectPoosY = Random.Range(reach*-1,reach);

                Vector2 newObjectPoos = new Vector2(newObjectPoosX,newObjectPoosY);
                newObjectPoos += (Vector2)transform.position;

                loadNewObject(newObjectPoos);
            }
            else if(objectPosition.y > reach)
            {
                unloadObject(checkObject);
                float newObjectPoosX = Random.Range(reach*-1,reach);
                float newObjectPoosY = reach*-1;

                Vector2 newObjectPoos = new Vector2(newObjectPoosX,newObjectPoosY);
                newObjectPoos += (Vector2)transform.position;

                loadNewObject(newObjectPoos);
            }
            else if(objectPosition.y < reach *-1)
            {
                unloadObject(checkObject);
                float newObjectPoosX = Random.Range(reach*-1,reach);
                float newObjectPoosY = reach;

                Vector2 newObjectPoos = new Vector2(newObjectPoosX,newObjectPoosY);
                newObjectPoos += (Vector2)transform.position;

                loadNewObject(newObjectPoos);
            }
        }
    }
    void populateEnviroment()
    {
        for(int i = 0; i < maxObjectLimit; i ++)
        {
            float newObjectPoosX = Random.Range(reach*-1,reach);
            float newObjectPoosY = Random.Range(reach*-1,reach);

            Vector3 newObjectPosition = new Vector3(newObjectPoosX,newObjectPoosY,0);


            loadNewObject(newObjectPosition);
        }
    }
    void unloadObject(GameObject unloadedObject)
    {
        Destroy(unloadedObject);
    }
    void loadNewObject(Vector2 newObjectPosition)
    {
        GameObject loadPrefab = pickRandomObject();
        GameObject newGameObject = Instantiate(loadPrefab,newObjectPosition,Quaternion.identity,objects_parent);

    }
    GameObject pickRandomObject()
    {
        float rng = Random.value;
        float chance_sum = 0;
        for(int i =0; i < Objects.Length;i++)
        {
            chance_sum += Objects[i].chance/100;

            if(rng < chance_sum) return Objects[i].prefab;
        }
        return null;
    }
}
[System.Serializable]
public class EnviromentObject
{
    public float chance;
    public GameObject prefab;
}