using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitBtn : MonoBehaviour
{
    public GameObject button;
    Animator btnAnim;
    public AudioSource soundButton;

    // Start is called before the first frame update
    void Start()
    {
        btnAnim = button.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnMouseEnter()
    {
        btnAnim.Play("quitClick");
        soundButton.Play();
        
        StartCoroutine(ExecuteAfterTime(1));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Application.Quit();
    }
}
