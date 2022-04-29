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
        spawnLocationSquare = spawnLocation.GetComponent<SpawnLocationSquare>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnLocationSquare.spawnTrigger();
        spawnTrigger.SetActive(false);
    }
}
