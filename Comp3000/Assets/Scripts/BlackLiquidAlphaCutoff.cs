using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackLiquidAlphaCutoff : MonoBehaviour
{
    public GameObject liquid;
    public Material blackSplatter;
    public float time = 100;
    public float maxTime = 100;
    public float currentXPosition;

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
        //check for time>=15 and if liquid position is != currentXPosition
        if (time >= 15 && liquid.transform.position.x != currentXPosition)
        {
            //removes 10 time every Time.deltaTime if time >=15
            time -= 10 * Time.deltaTime;
            //compares time from maxTime
            blackSplatter.SetFloat("_Cutoff", time / maxTime);

            animator.SetTrigger("afterStart");
        }

        
        //check if time<=15 and if currentXPosition != liquid.transform.position.x
        if (time <= 15 && currentXPosition != liquid.transform.position.x)
        {
            time = 100;
            currentXPosition = liquid.transform.position.x;
        }
    }
}
