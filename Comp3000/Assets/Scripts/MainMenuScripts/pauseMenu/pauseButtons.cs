using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButtons : MonoBehaviour
{
    GameObject resumeBtn;

    // Start is called before the first frame update
    void Start()
    {
        resumeBtn = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeBtn()
    {
        resumeBtn.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("menu..");
    }

    public void QuitToDesk()
    {
        Application.Quit();
        Debug.Log("quitting...");
    }

    public void OnMouseEnter()
    {
        resumeBtn.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
