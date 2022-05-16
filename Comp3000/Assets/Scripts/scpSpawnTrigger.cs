using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scpSpawnTrigger : MonoBehaviour
{
    public GameObject spawnTrigger;
    public GameObject spawnLocation;
    SpawnLocationSquare spawnLocationSquare;

    // Start is called before the first frame update
    void Start()
    {
        //gets SpawnLocationSquare script
        spawnLocationSquare = spawnLocation.GetComponent<SpawnLocationSquare>();
    }

    //when player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //call this method
        spawnLocationSquare.spawnTrigger();
        //set spawntrigger to false
        spawnTrigger.SetActive(false);
    }
}
