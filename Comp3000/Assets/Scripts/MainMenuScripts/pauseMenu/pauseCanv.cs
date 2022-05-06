using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseCanv : MonoBehaviour
{
    public GameObject pauseCanvas;
    GameObject canvasChild;


    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = GameObject.Find("pauseCanvas");
        canvasChild = pauseCanvas.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(canvasChild.activeInHierarchy == false)
            {
                canvasChild.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;

            }
            else if(canvasChild.activeInHierarchy == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                canvasChild.SetActive(false);
            }
        }
    }
}
