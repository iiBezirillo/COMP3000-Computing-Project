using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    private Transform player;
    private Transform ScpPos;
    private NavMeshAgent nav;
    public GameObject SCP106;
    public GameObject deSpawnLiquid;

    private float valuesReset = 10;
    public float countDown;
    public float deSpawnCountDown = 10;
    public float disableSCPCountDown = 13;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //gets animator from Scp-106 prefab
        animator = GetComponentInChildren<Animator>();

        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //finds objects with the "Player" tag 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //finds Scp-106 with the "Scp106" tag
        ScpPos = GameObject.FindGameObjectWithTag("Scp106").transform;
        //gets navMeshAgent component
        nav = GetComponent<NavMeshAgent>();

        //if count down is > 0 then start start timer
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        //if count down is < 0 start chasing with destination the player
        else if(countDown < 0)
        {
            animator.SetBool("isChasing", true);
            nav.SetDestination(player.position);
        }

        //if this countdown starts despawn anim will begin
        if (deSpawnCountDown > 0)
        {
            deSpawnCountDown -= Time.deltaTime;
        }
        else if (deSpawnCountDown < 0)
        {
            animator.SetBool("stopChasing", true);
            nav.SetDestination(ScpPos.position);

            //enable black liquid 
            deSpawnLiquid.SetActive(true);
            //make sure liquid spawns correctly to the ground
            deSpawnLiquid.transform.position = new Vector3(ScpPos.transform.position.x, .1f, ScpPos.transform.position.z);
        }

        //count down for disabling SCP-106 
        if (disableSCPCountDown > 0)
        {
            disableSCPCountDown -= Time.deltaTime;
        }
        //after count down reset some values, chase no more and disable SCP-106 object
        else if (disableSCPCountDown < 0)
        {
            countDown = 6;
            deSpawnCountDown = valuesReset + 5;
            disableSCPCountDown = valuesReset + 7;
            animator.SetBool("isChasing", false);
            animator.SetBool("stopChasing", false);

            SCP106.SetActive(false);
        }
    }
}
