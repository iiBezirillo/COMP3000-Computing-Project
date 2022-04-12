using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationSquare : MonoBehaviour
{
    public Vector3 radius;

    public GameObject SCP106;
    //public GameObject spawnLiquid;
    //public GameObject DeSpawnLiquid;

    void Update()
    {

        //when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //enable SCP-106
            SCP106.SetActive(true);
            //make sure he spawns correctly to the ground
            SCP106.transform.position = new Vector3(transform.position.x, 2.632f, transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, 3.4f, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        //a "window" that helps me see the spawn location
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, radius);
    }
}
