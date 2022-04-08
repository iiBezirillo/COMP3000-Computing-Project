using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    public GameObject SCP106;

    public float countDown = 6;
    public float disableCountDown = 15;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponentInChildren<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else if(countDown < 0)
        {
            animator.SetBool("isChasing", true);
            nav.SetDestination(player.position);
        }

        if (disableCountDown > 0)
        {
            disableCountDown -= Time.deltaTime;
        }
        else if (disableCountDown < 0)
        {
            countDown = 6;
            disableCountDown = 15;
            animator.SetBool("isChasing", false);

            SCP106.SetActive(false);
        }
    }
}
