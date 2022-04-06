using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationSquare : MonoBehaviour
{
    public Vector3 radius;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 3.4f, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, radius);
    }
}
