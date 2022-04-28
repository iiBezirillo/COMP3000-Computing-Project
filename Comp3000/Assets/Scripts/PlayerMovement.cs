﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    public CharacterController controller;

    [Header("floats")]
    public float speed = 10;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    float lastTime;
    
    //jump
    //public float jumpHeight = 3f;

    [Header("Transforms")]
    public Transform groundCheck;

    [Header("Layer Mask")]
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    [Header("Animators")]
    public Animator playerAnimator;

    [Header("Colliders")]
    public Collider death;


    private void Start()
    {
        //framerate set to approx 50 for my pc to live longer
        Application.targetFrameRate = 50;

        lastTime = Time.time;

        //gets crouch animation component
        playerAnimator = GetComponent<Animator>();

        //fetch player collider
        death = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        //ground check 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //simple movement code
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jump
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // if c is pressed crouch if not crouch and not crouch if crouch
        if (Input.GetKeyDown("c") && (Time.time - lastTime > 1))
        {
            if(speed == 10f)
            {
                this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Crouch OFF");
                speed = speed - 5f;
                playerAnimator.Play("Crouch ON");
            }
            else if(speed == 5f)
            {
                this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Crouch ON");

                StartCoroutine(ExecuteAfterTime(.30f));
                IEnumerator ExecuteAfterTime(float time)
                {
                    yield return new WaitForSeconds(time);
                    
                    speed = speed + 5f;

                }
                playerAnimator.Play("Crouch OFF");
            }
            lastTime = Time.time;
        }

        //if shift is pressed then take speed and add five to run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (speed == 10)
            {
                speed = speed + 5;

            }
        }
        //if shift is pressed no more then take speed == 15 and take away 5 to walk
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (speed == 15f)
            {
                speed = speed - 5f;
            }
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    playerAnimator.Play("Death");
    //}
}
