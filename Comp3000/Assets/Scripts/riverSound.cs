using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riverSound : MonoBehaviour
{
    Transform soundFollow;

    // Start is called before the first frame update
    void Start()
    {
        //finds soundFollow
        soundFollow = GameObject.Find("First Person Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Follows player on X position ONLY
        transform.position = new Vector3(soundFollow.position.x, transform.position.y, transform.position.z);
    }
}
