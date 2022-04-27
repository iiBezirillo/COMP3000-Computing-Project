using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscaretrigger;
    public GameObject jumpscareCanvas;

    private void OnTriggerEnter(Collider other)
    {
        jumpscareCanvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        jumpscareCanvas.SetActive(false);
        jumpscaretrigger.SetActive(false);

    }
}
