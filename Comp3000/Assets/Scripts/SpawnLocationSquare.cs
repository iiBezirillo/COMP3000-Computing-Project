using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationSquare : MonoBehaviour
{
    public Vector3 radius;

    public GameObject SCP106;
    public GameObject liquid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SCP106.SetActive(true);
            SCP106.transform.position = new Vector3(transform.position.x, 2.632f, transform.position.z);

            liquid.SetActive(true);
            liquid.transform.position = new Vector3(transform.position.x, .1f, transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, 3.4f, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, radius);
    }

    //void spawn()
    //{
    //}
}
