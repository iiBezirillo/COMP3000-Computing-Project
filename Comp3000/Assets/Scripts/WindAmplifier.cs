using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAmplifier : MonoBehaviour
{
    public GameObject windTrigger;

    private void Update()
    { 
    }

    //When player enter the trigger
    private void OnTriggerEnter(Collider other)
    {
        //find the sound "smoothWind" and raise its volume to 0.8
        FindObjectOfType<SoundManager>().Fade("smoothWind", 7, .8f);
    }

    //when player leave the trigger box
    private void OnTriggerExit(Collider other)
    {
        //find the sound "smoothWind" and lower its volume back to 0.1
        FindObjectOfType<SoundManager>().Fade("smoothWind", 7, .1f);
    }
}
