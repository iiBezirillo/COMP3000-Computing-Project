using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    private Transform player;
    private Transform navScpPos;

    private NavMeshAgent nav;
    public GameObject SCP106;
    public GameObject deSpawnLiquid;
    public GameObject spawnLiquid;

    private float valuesReset = 5;
    public float countDown;
    public float deSpawnCountDown = 3;
    public float disableSCPCountDown = 13;

    Animator animator;
    public Animator animDeSpawnLiquid;
    public Animator animSpawnLiquid;

    // Start is called before the first frame update
    void Start()
    {
        //gets animator from Scp-106 prefab
        animator = GetComponentInChildren<Animator>();
        animDeSpawnLiquid = animDeSpawnLiquid.GetComponent<Animator>();
        animSpawnLiquid = animSpawnLiquid.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //finds objects with the "Player" tag 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //finds Scp-106 with the "Scp106" tag
        navScpPos = GameObject.FindGameObjectWithTag("Scp106").transform;

        //gets navMeshAgent component
        nav = GetComponent<NavMeshAgent>();

        //if count down is > 0 then start spawn timer
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;

            //enable spawn liquid 
            spawnLiquid.SetActive(true);
            //make sure liquid spawns correctly to the ground
            spawnLiquid.transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);

            if(countDown < 6 && countDown > 5.95f)
            {
                animSpawnLiquid.SetTrigger("beforeStart");
            }

        }
        //if count down is < 0 start chasing with destination the player
        else if(countDown < 0)
        {
            animator.SetBool("isChasing", true);
            nav.SetDestination(player.position);

            disableSCPCountDown -= Time.deltaTime;

            //count down for disabling SCP-106 
            if (disableSCPCountDown <= 3)
            {
                deSpawnCountDown -= Time.deltaTime;
            }
        }

        //if this countdown starts despawn anim will begin
        if (deSpawnCountDown < 3)
        {
            animator.SetBool("stopChasing", true);
            nav.SetDestination(navScpPos.position);

            //enable deSpawn liquid 
            deSpawnLiquid.SetActive(true);
            //make sure liquid spawns correctly to the ground
            deSpawnLiquid.transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);

            if(deSpawnCountDown < 3 && deSpawnCountDown > 2.95)
            {
                animDeSpawnLiquid.SetTrigger("beforeStart");
            }

        }

        if (disableSCPCountDown < 0)
        {
            countDown = 6;
            deSpawnCountDown = 3;
            disableSCPCountDown = valuesReset;
            animator.SetBool("isChasing", false);
            animator.SetBool("stopChasing", false);

            SCP106.SetActive(false);
        }
    }
}
