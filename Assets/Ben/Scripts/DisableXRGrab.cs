using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableXRGrab : MonoBehaviour
{
    public XRGrabInteractable interactable;
  
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lid")
        {
            interactable.enabled = false;
        }
    }

}
