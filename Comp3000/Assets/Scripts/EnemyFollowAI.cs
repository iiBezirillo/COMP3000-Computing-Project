using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    [Header("Transforms")]
    private Transform player;
    private Transform navScpPos;

    [Header("NavMesh")]
    private NavMeshAgent nav;

    [Header("Game Objects")]
    public GameObject SCP106;
    public GameObject deSpawnLiquid;
    public GameObject spawnLiquid;
    public GameObject trailLiquid;
    public GameObject cloneTrailLiquid;
    public GameObject spawnLocation;
    public GameObject playerCamera;

    [Header("Timers")]
    public float spawnCountDown = 4;
    public float deSpawnCountDown = 3;
    public float disableSCPCountDown = 41;
    public float trailTime = 0;

    Animator animator;
    [Header("Animators")]
    public Animator animSpawnLiquid;
    public Animator animDeSpawnLiquid;
    public Animator animTrailLiquid;
    public Animator Scp106;

    [Header("Colliders")]
    public Collider handColl;

    bool invokeOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        //gets animators
        animator = GetComponentInChildren<Animator>();
        animDeSpawnLiquid = animDeSpawnLiquid.GetComponent<Animator>();
        animSpawnLiquid = animSpawnLiquid.GetComponent<Animator>();
        animTrailLiquid = animTrailLiquid.GetComponent<Animator>();
        Scp106 = Scp106.GetComponent<Animator>();

        //Fetch scp's Collider
        handColl = GetComponent<Collider>();
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
        if (spawnCountDown > 0)
        {

            spawnCountDown -= Time.deltaTime;

            //enable spawn liquid 
            spawnLiquid.SetActive(true);
            //make sure liquid spawns correctly to the ground
            spawnLiquid.transform.position = new Vector3(transform.position.x, transform.position.y - 2.1f, transform.position.z);

            if (spawnCountDown < 4 && spawnCountDown > 3.95f)
            {
                animSpawnLiquid.SetTrigger("beforeStart");
            }
        }
        //if count down is < 0 start chasing with destination the player
        else if(spawnCountDown < 0)
        {
            animator.SetBool("isChasing", true);
            nav.SetDestination(player.position);

            disableSCPCountDown -= Time.deltaTime;

            handColl.enabled = true;


            //count down for disabling SCP-106 
            if (disableSCPCountDown <= 3)
            {
                deSpawnCountDown -= Time.deltaTime;
            }


            //~trailLiquid~
            if (spawnCountDown < 0 && disableSCPCountDown > 3)
            {
                if (!invokeOnce)
                {
                    //enable spawn liquid 
                    trailLiquid.SetActive(true);
                    InvokeRepeating("spawnTrailLiquid", 0.3f, 0.3f);
                    invokeOnce = true;
                }
            }
            else if (deSpawnCountDown < 3)
            {
                CancelInvoke();
                trailLiquid.SetActive(false);
                invokeOnce = false;

                //fade chaseSong
                FindObjectOfType<SoundManager>().Fade("chaseSong", 2, .1f);
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
            deSpawnLiquid.transform.position = new Vector3(transform.position.x, transform.position.y - 2.1f, transform.position.z);

            Scp106.SetTrigger("armDown");
            handColl.enabled = false;
            
            CancelInvoke();

            if (deSpawnCountDown < 3 && deSpawnCountDown > 2.95)
            {
                animDeSpawnLiquid.SetTrigger("beforeStart");
            }

        }

        if (disableSCPCountDown < 0)
        {
            spawnCountDown = 4;
            deSpawnCountDown = 3;
            disableSCPCountDown = 41;
            animator.SetBool("isChasing", false);
            animator.SetBool("stopChasing", false);

            SCP106.SetActive(false);
            SCP106.transform.SetParent(player);
            SCP106.transform.position = spawnLocation.transform.position;

            //stop Chase Song            
            FindObjectOfType<SoundManager>().Stop("chaseSong");
            FindObjectOfType<SoundManager>().Play("SCP106 Laugh");


        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
        Scp106.SetTrigger("armUp");
        
    }

    public void OnTriggerExit(Collider other)
    {
        Scp106.SetTrigger("armDown");
    }

    public void spawnTrailLiquid()
    {
        cloneTrailLiquid = Instantiate(trailLiquid);
        cloneTrailLiquid.transform.position = new Vector3(transform.position.x, transform.position.y - 2.1f, transform.position.z);
        cloneTrailLiquid.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
