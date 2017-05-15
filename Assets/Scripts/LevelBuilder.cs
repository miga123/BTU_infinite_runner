using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public Transform player;
    public GameObject[] platforms;  
    public int numberOrStartingPlatform;
    public float destroyTime = 5f;

    public Vector3 platformSpawnPoint = Vector3.zero;
    
    //-----------------Unity Fuctions: -------------------
    void Start()
    {
        int counter = 0;

        
        while(counter < numberOrStartingPlatform)
        {
            CreateNextPlatform();
            counter = counter + 1;
        }    
    }

    int pp;
    int lastPP;
    void Update()
    {
        //nubmer of 50 metres distance sassed
         pp = (int)player.position.z / 50;

        //
        if(pp > lastPP)
        {
            CreateNextPlatform();
        }

        lastPP = pp;
    }

    //-----------------my Custom Fuctions: -----------------
    void CreateNextPlatform()
    {
        Debug.Log("create Platform");
        //move starting position z axis
        platformSpawnPoint.z = platformSpawnPoint.z + 50f;

        int platformChooser = Random.Range(0, platforms.Length);

        //create a new Gameobject
        GameObject clone;
        clone = Instantiate ( platforms[ platformChooser ]);

        //move the new Gameobject
        clone.transform.position = platformSpawnPoint;

        Destroy(clone, destroyTime);
    }
}
