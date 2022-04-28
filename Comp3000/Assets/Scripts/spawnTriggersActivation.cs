using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTriggersActivation : MonoBehaviour
{
    public GameObject[] spawnTriggers;
    public float timer = 600;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {          
            if(spawnTriggers[0].activeInHierarchy == false)
            {
                spawnTriggers[0].SetActive(true);

            }
            if (spawnTriggers[1].activeInHierarchy == false)
            {
                spawnTriggers[1].SetActive(true);

            }
            if (spawnTriggers[2].activeInHierarchy == false)
            {
                spawnTriggers[2].SetActive(true);

            }
            if (spawnTriggers[3].activeInHierarchy == false)
            {
                spawnTriggers[3].SetActive(true);

            }
            if (spawnTriggers[4].activeInHierarchy == false)
            {
                spawnTriggers[4].SetActive(true);

            }
            if (spawnTriggers[5].activeInHierarchy == false)
            {
                spawnTriggers[5].SetActive(true);

            }
            timer = 600f;
        }
    }
}
