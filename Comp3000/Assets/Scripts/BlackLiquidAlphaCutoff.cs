using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackLiquidAlphaCutoff : MonoBehaviour
{
    public GameObject liquid;
    public Material blackSplatter;
    public float time = 100;
    public float maxTime = 100;

    public float disableLiquidCountDown = 15;

    // Start is called before the first frame update
    void Start()
    {
        blackSplatter.SetFloat("_Cutoff", time / maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //removes 10 time every Time.deltaTime if time >=15
        if (time >= 15)
        {
            time -= 10 * Time.deltaTime;
            //compares time from maxTime
            blackSplatter.SetFloat("_Cutoff", time / maxTime);
        }


        //countDown for disabling black liquid and resetting time
        if (disableLiquidCountDown > 0)
        {
            disableLiquidCountDown -= Time.deltaTime;
        }
        else if (disableLiquidCountDown < 0)
        {

            disableLiquidCountDown = 15;

            time = 100;
            maxTime = 100;

            liquid.SetActive(false);
        }
    }
}
