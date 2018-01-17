using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject ObjectToSpawn;
    public GameObject Player;
    public float DistanceSpawn = 50f;
    public float SpawnRate = 2f;
    float NextSpawn;

    void Update () {

        float distance = Vector3.Distance(Player.transform.position, transform.position);
       // Debug.Log(distance);
        if(distance < DistanceSpawn && Time.time>NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
            
        }
	}
}
