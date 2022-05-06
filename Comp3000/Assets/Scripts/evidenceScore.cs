using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class evidenceScore : MonoBehaviour
{
    public Text scoreText;

    int previousScore;

    public GameObject cameraPlayer;
    itemRaycast  raycastScript;

    public Animator canvasAnim;
    private void Awake()
    {
        canvasAnim = canvasAnim.GetComponent<Animator>();

        raycastScript = cameraPlayer.GetComponent<itemRaycast>();
    }

    // Update is called once per frame
    void Update()
    {
        if(previousScore != raycastScript.score)
        {
            previousScore = previousScore + 1;
            canvasAnim.Play("scoreAnimation", -1, 0);
        }
        if(previousScore == 0)
        {
            scoreText.text = raycastScript.score.ToString() + "/5 evidence found\n\nE = pick Items\nLeft Shift = Run\nG = Flashlight\n C = Crouch";
        }
        else if (previousScore >= 1 && previousScore <= 4)
        {
            scoreText.text = raycastScript.score.ToString() + "/5 evidence found";
        }
        else if (previousScore == 5)
        {
            scoreText.text = raycastScript.score.ToString() + "/5 evidence found. " + "All Evidence Collected. " + "Better get to the car.";
        }
    }
}
