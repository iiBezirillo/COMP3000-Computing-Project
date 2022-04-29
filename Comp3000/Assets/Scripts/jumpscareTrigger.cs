using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscaretrigger;
    public GameObject jumpscareCanvas;
    public int randomNumber;

    private void OnTriggerEnter(Collider other)
    {
        jumpscareCanvas.SetActive(true);

        if (randomNumber == 0)
        {
            FindObjectOfType<SoundManager>().Play("jumpScareG");

        }
        else if (randomNumber == 1)
        {
            FindObjectOfType<SoundManager>().Play("jumpScareB");
        }
        else if (randomNumber == 2)
        {
            FindObjectOfType<SoundManager>().Play("jumpScareF");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        jumpscareCanvas.SetActive(false);
        jumpscaretrigger.SetActive(false);
    }
}
