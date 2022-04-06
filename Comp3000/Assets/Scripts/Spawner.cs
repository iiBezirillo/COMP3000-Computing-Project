using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] toSpawnPrefab;
    public GameObject[] toSpawnClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawn();
        }

    }

    void spawn()
    {
        toSpawnClone[0] = Instantiate(toSpawnPrefab[0], spawnLocations[0].transform.position,
            Quaternion.Euler(0, 0, 0)) as GameObject;

    }
}
