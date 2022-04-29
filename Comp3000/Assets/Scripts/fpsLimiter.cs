using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLimiter : MonoBehaviour
{
    private void Start()
    {
        //framerate set to approx 50 for my pc to live longer
        Application.targetFrameRate = 50;
    }
}
