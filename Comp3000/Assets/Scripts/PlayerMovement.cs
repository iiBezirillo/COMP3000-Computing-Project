using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10;

    public float gravity = -9.81f;
    //jump
    //public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    float lastTime;

    public Animator crouchAnim;

    private void Start()
    {
        lastTime = Time.time;

        crouchAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

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

        if (Input.GetKeyDown("c") && (Time.time - lastTime > 1))
        {
            if(speed == 10f)
            {
                this.crouchAnim.GetCurrentAnimatorStateInfo(0).IsName("Crouch OFF");
                speed = speed - 5f;
                crouchAnim.Play("Crouch ON");
            }
            else if(speed == 5f)
            {
                this.crouchAnim.GetCurrentAnimatorStateInfo(0).IsName("Crouch ON");

                StartCoroutine(ExecuteAfterTime(.30f));
                IEnumerator ExecuteAfterTime(float time)
                {
                    yield return new WaitForSeconds(time);
                    
                    speed = speed + 5f;

                }
                crouchAnim.Play("Crouch OFF");
            }
            lastTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (speed == 10)
            {
                speed = speed + 5;

            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (speed == 15f)
            {
                speed = speed - 5f;
            }
        }
    }
}
