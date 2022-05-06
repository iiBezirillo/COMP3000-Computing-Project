using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playBtn : MonoBehaviour
{
    public GameObject button;
    Animator btnAnim;
    public AudioSource soundButton;

    public GameObject fade;
    Animator animFade;

    // Start is called before the first frame update
    void Start()
    {
        btnAnim = button.GetComponent<Animator>();

        animFade = fade.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnMouseEnter()
    {
        btnAnim.Play("playClick");
        soundButton.Play();
        animFade.Play("mainMenuFade");

        StartCoroutine(ExecuteAfterTime(1));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
