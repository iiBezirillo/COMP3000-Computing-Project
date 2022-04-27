using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInter;
    [SerializeField] private string excludeLayerName = null;

    private itemController rayCastedObj;

    [SerializeField] private KeyCode pickObj = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrossHairActive;
    private bool doOnce;

    private const string interactableTag = "item";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInter.value;
        //Debug.DrawRay(transform.position, fwd, Color.green);
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    rayCastedObj = hit.collider.gameObject.GetComponent<itemController>();
                    CrossHairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(pickObj))
                {
                    //rayCastedObj.pickUpItem();
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (isCrossHairActive)
            {
                CrossHairChange(false);
                doOnce = false;
            }
        }
    }

    void CrossHairChange(bool on)
    {
        if(on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrossHairActive = false;
        }
    }
}
