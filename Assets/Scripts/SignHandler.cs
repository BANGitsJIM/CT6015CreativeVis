using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignHandler : MonoBehaviour
{
    public GameObject prefab;
    public GameObject terrain;
    public float NumberOfSigns;
    public float XCoordA;
    public float XCoordB;
    public float ZCoordA;
    public float ZCoordB;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn objects when initialising on start depending on how many signs have been requested.
        for (int i = 0; i < NumberOfSigns; i++)
        {
            //Debug.Log("Spawn");
            generateObjectOnTerrain();
        }
    }

    public void generateObjectOnTerrain()
    {
        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(XCoordA, XCoordB);
        float randZ = UnityEngine.Random.Range(ZCoordA, ZCoordB);
        float randRot = UnityEngine.Random.Range(-360, 360);
        float yVal = 0.2f;

        //Generate the Prefab on the generated position
        GameObject objInstance = (GameObject)Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.Euler(-90, randRot, 90));

        //Debug.Log("Spawn at X:" + randX + "  Z:" + randZ);
    }
}