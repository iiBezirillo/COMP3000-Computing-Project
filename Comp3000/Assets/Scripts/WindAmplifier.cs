using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAmplifier : MonoBehaviour
{
    public GameObject windTrigger;

    private void Update()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SoundManager>().Fade("smoothWind", 7, .8f);
    }
    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<SoundManager>().Fade("smoothWind", 7, .1f);
    }
}
