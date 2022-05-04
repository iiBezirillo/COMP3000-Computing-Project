using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingSongTrigger : MonoBehaviour
{
    public GameObject EndingSongTrigger;
    public Collider endSongCollider;


    [Header("Taking Score")]
    itemRaycast raycastScore;
    public GameObject rayCamera;
    public int finalScore;

    private void Start()
    {
        raycastScore = rayCamera.GetComponent<itemRaycast>();

    }

    private void Update()
    {
        finalScore = raycastScore.score;

        if(finalScore == 5)
        {
            endSongCollider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SoundManager>().Play("background1");
        EndingSongTrigger.SetActive(false);
    }
}
