using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public Transform spawnLocations;
    public GameObject toSpawnPrefab;
    public GameObject toSpawnClone;

    public GameObject trail;
    //public EnemyFollowAI enemyFollowAI;

    // Start is called before the first frame update
    void Start()
    {
        trail = GameObject.FindWithTag("Trail");
        //enemyFollowAI = Scp106.GetComponent<EnemyFollowAI>();

        InvokeRepeating("spawn", 6.5f, 0.5f);

        trail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        toSpawnClone.transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);
        toSpawnClone.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.P))
        {
            trail.SetActive(false);
        }


    }

    //spawn method to spawn a clone
    void spawn()
    {
        toSpawnClone = Instantiate(toSpawnPrefab) as GameObject;
        
    }
}
