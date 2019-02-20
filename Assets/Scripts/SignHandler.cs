﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignHandler : MonoBehaviour
{
    public GameObject prefab;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        generateObjectOnTerrain();
    }

    public void generateObjectOnTerrain()
    {
        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(-34, 7);
        float randZ = UnityEngine.Random.Range(-17, 24);
        float yVal = 1f;

        //Generate the Prefab on the generated position
        GameObject objInstance = (GameObject)Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.Euler(-90, 90, 90));

        //Debug.Log("Spawn at X:" + randX + "  Z:" + randZ);
    }
}