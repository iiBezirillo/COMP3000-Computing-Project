using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Animator anim;

    float lastTime;

    private GameObject lightObject;
    private Light myLightComponent;


    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;

        //lightObject assigned to "Spot Light"
        lightObject = GameObject.Find("Spot Light");
        myLightComponent = lightObject.GetComponent<Light>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //press g to show/hide flashlight
        if (Input.GetKeyDown("g") && (Time.time - lastTime > 1))
        {
            //if "Show Flashlight" anim is in place 
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Show Flashlight"))
            {
                myLightComponent.enabled = !myLightComponent;

                //Coroutine for a short delay
                StartCoroutine(ExecuteAfterTime(.25f));
                IEnumerator ExecuteAfterTime(float time)
                {
                    yield return new WaitForSeconds(time);

                    //Disables the spot light
                    anim.Play("Hide Flashlight");
                }   
            }
            //if "Hide Flashlight" anim is in place 
            else if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Hide Flashlight"))
            {
                //enables the spot light
                anim.Play("Show Flashlight");

                StartCoroutine(ExecuteAfterTime(1));
                IEnumerator ExecuteAfterTime(float time)
                {
                    yield return new WaitForSeconds(time);

                    myLightComponent.enabled = myLightComponent;
                }
            }
            lastTime = Time.time;
        }
    }
}
