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

    /// <summary>
    /// Once the gameobject enters the collider area of a gameobject with Lid the XR grab script disables
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lid")
        {
            interactable.enabled = false;
        }
    }

}
