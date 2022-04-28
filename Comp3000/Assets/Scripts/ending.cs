using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    [Header("Taking Score")]
    itemRaycast raycastScore;
    public GameObject rayCamera;
    public int finalScore;

    public Collider endCollider;

    [Header("Spawning SCP106")]
    public GameObject spawnTrigger;
    public GameObject spawnLocation;
    SpawnLocationSquare spawnLocationSquare;

    [Header("Taking Player Script")]
    public GameObject player;
    PlayerMovement playerMovement;

    [Header("Taking Camera Script")]
    public GameObject playerCamera;
    MouseLook mouseLook;

    [Header("Taking child object")]
    public GameObject endingLiquid;


    // Start is called before the first frame update
    void Start()
    {
        raycastScore = rayCamera.GetComponent<itemRaycast>();
        spawnLocationSquare = spawnLocation.GetComponent<SpawnLocationSquare>();
        endCollider = GetComponent<Collider>();
        playerMovement = player.GetComponent<PlayerMovement>();
        mouseLook = playerCamera.GetComponent<MouseLook>();
        //endingLiquid = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = raycastScore.score;

        if (finalScore == 5)
        {
            endCollider.enabled = true;
            endingLiquid.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnLocationSquare.spawnTrigger();
        spawnTrigger.SetActive(false);
        playerMovement.speed = 1;
        mouseLook.mouseSensitivity = 20;
    }
}
