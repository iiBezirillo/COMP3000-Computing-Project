using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    public CharacterController controller;

    [Header("floats")]
    public float speed = 7;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    float lastTime;
    public bool soundWalk = false;

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

    //sound parameters
    [SerializeField] private bool soundOn;

    private void Start()
    {
        
        lastTime = Time.time;

        //gets crouch animation component
        playerAnimator = GetComponent<Animator>();

        //fetch player collider
        death = GetComponent<Collider>();

        //plays grassFootstep sound
        FindObjectOfType<SoundManager>().Play("grassFootstep");

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

        Vector3 move = transform.right.normalized * x + transform.forward.normalized * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jump
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //if you get these key inputs
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")
           || Input.GetKey("w") && Input.GetKey("a") || Input.GetKey("w") && Input.GetKey("d"))
        {
            //increase volume to 0.2
            FindObjectOfType<SoundManager>().Fade("grassFootstep", .2f, .2f);

        }
        else if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
        {
            //decrease the volume to 0
            FindObjectOfType<SoundManager>().Fade("grassFootstep", .2f, 0f);
        }


        // if c is pressed crouch if not crouch and not crouch if crouch
        if (Input.GetKeyDown("c") && (Time.time - lastTime > 1))
        {
            if(speed == 7f)
            {
                this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Crouch OFF");
                speed = speed - 2f;
                playerAnimator.Play("Crouch ON");
            }
            else if(speed == 5f)
            {
                this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Crouch ON");

                StartCoroutine(ExecuteAfterTime(.30f));
                IEnumerator ExecuteAfterTime(float time)
                {
                    yield return new WaitForSeconds(time);
                    
                    speed = speed + 2f;

                }
                playerAnimator.Play("Crouch OFF");
            }
            lastTime = Time.time;
        }

        //if shift is pressed then take speed and add three to run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (speed == 7)
            {
                speed = speed + 3;

            }
        }
        //if shift is not pressed 
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            //if speed is 10 
            if (speed == 10f)
            {
                //then take three
                speed = speed - 3f;
            }
        }
    }
}
