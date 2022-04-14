using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackLiquidTrail : MonoBehaviour
{
    public GameObject liquid;

    public Material blackSplatter;

    public float time = 100;
    public float maxTime = 100;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //spawnAnim = GetComponent<Animator>();

        blackSplatter.SetFloat("_Cutoff", time / maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 50)
        {
            time -= 10 * Time.deltaTime;
            //compares time from maxTime
            blackSplatter.SetFloat("_Cutoff", time / maxTime);
        }
    }
}
