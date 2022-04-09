using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackLiquidAlphaCutoff : MonoBehaviour
{
    public GameObject liquid;
    public Material blackSplatter;
    public float health;
    public float maxHealth;

    public float disableLiquidCountDown = 15;

    // Start is called before the first frame update
    void Start()
    {
        blackSplatter.SetFloat("_Cutoff", health / maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 15)
        {
            health -= 10 * Time.deltaTime;
            blackSplatter.SetFloat("_Cutoff", health / maxHealth);
        }


        if (disableLiquidCountDown > 0)
        {
            disableLiquidCountDown -= Time.deltaTime;
        }
        else if (disableLiquidCountDown < 0)
        {

            disableLiquidCountDown = 15;

            health = 100;
            maxHealth = 100;

            liquid.SetActive(false);
        }
    }
}
