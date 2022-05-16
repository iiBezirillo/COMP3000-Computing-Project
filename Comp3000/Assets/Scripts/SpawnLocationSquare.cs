using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationSquare : MonoBehaviour
{
    public Vector3 radius;

    public GameObject SCP106;
    public GameObject SpawnLocation;


    void Update()
    {

        //when space is pressed
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //enable SCP-106
        //    SCP106.SetActive(true);
        //    //make sure he spawns correctly to the ground
        //    SCP106.transform.position = SpawnLocation.transform.position;
        //    SCP106.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        //    SCP106.transform.SetParent(null);
        //}

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    //a gizmos "window" that helps me see the spawn location
    private void OnDrawGizmos()
    {
        //make gizmos green
        Gizmos.color = Color.green;
        //draw a cube wire
        Gizmos.DrawWireCube(this.transform.position, radius);
    }

    public void spawnTrigger()
    {
        //enable SCP-106
        SCP106.SetActive(true);
        //make sure he spawns correctly to the position
        SCP106.transform.position = SpawnLocation.transform.position;
        SCP106.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        //leave the player parent
        SCP106.transform.SetParent(null);

        //sound
        FindObjectOfType<SoundManager>().Play("spawnSound");
        FindObjectOfType<SoundManager>().Fade("chaseSong", 2, 1f);
        FindObjectOfType<SoundManager>().Play("chaseSong");

    }
}
