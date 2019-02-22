using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSignHandler : MonoBehaviour
{
    public GameObject prefab;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn two objects when initialising start.
        generateObjectOnTerrain();
    }

    public void generateObjectOnTerrain()
    {
        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(-6, 15);
        float randZ = UnityEngine.Random.Range(6, -15);
        float randRot = UnityEngine.Random.Range(-360, 360);
        float yVal = 0.2f;

        //Generate the Prefab on the generated position
        GameObject objInstance = (GameObject)Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.Euler(-90, randRot, 90));

        //Debug.Log("Spawn at X:" + randX + "  Z:" + randZ);
    }
}
