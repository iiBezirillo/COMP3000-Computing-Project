using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTriggersActivation : MonoBehaviour
{
    //array of gameobjects
    public GameObject[] spawnTriggers;

    //a timer
    public float timer = 600;


    // Update is called once per frame
    void Update()
    {
        //timer starts to decrease
        timer -= Time.deltaTime;


        //if timer goes to zero
        if (timer < 0)
        {   
            //if the first gameobject trigger is false
            if(spawnTriggers[0].activeInHierarchy == false)
            {
                //make this trigger active again
                spawnTriggers[0].SetActive(true);

            }

            //if the second gameobject trigger is false
            if (spawnTriggers[1].activeInHierarchy == false)
            {
                //make this trigger active again
                spawnTriggers[1].SetActive(true);

            }

            //if the third gameobject trigger is false
            if (spawnTriggers[2].activeInHierarchy == false)
            {
                //make this trigger active again
                spawnTriggers[2].SetActive(true);

            }

            //if the fourth gameobject trigger is false
            if (spawnTriggers[3].activeInHierarchy == false)
            {
                //make this trigger active again
                spawnTriggers[3].SetActive(true);

            }

            //if the fifth gameobject trigger is false
            if (spawnTriggers[4].activeInHierarchy == false)
            {
                //make this trigger active again
                spawnTriggers[4].SetActive(true);

            }

            //if the first sixth trigger is false
            if (spawnTriggers[5].activeInHierarchy == false)
            {
                //make this trigger active again
                spawnTriggers[5].SetActive(true);

            }

            //make timer = 600
            timer = 600f;
        }
    }
}
