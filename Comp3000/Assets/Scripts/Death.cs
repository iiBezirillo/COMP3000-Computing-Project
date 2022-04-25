using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    PlayerMovement playerMovement;
    public GameObject player;

    Animator mainCamAnim;
    MouseLook mouseLook;
    public GameObject playerCamera;

    FlashlightController flashlightController;
    Animator animArmature;
    public GameObject armature;

    EnemyFollowAI enemyFollowAI;
    public GameObject Scp106;

    public GameObject deathCanvas;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        mouseLook = playerCamera.GetComponent<MouseLook>();
        mainCamAnim = playerCamera.GetComponent<Animator>();
        animArmature = armature.GetComponent<Animator>();
        flashlightController = armature.GetComponent<FlashlightController>();
        enemyFollowAI = Scp106.GetComponent<EnemyFollowAI>();
    }


    private void OnTriggerEnter(Collider other)
    {
        playerMovement.speed = 0;
        mouseLook.mouseSensitivity = 0;
        mainCamAnim.enabled = true;
        animArmature.Play("Hide Flashlight");
        armature.GetComponent<FlashlightController>().enabled = false;
        deathCanvas.SetActive(true);
        enemyFollowAI.disableSCPCountDown = 3;
    }
}
