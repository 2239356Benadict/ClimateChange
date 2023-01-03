using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinForPlastic : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Plastic")
        {
            Debug.Log("Plastic waste in plastic bin");
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            Debug.Log("Bio in plastic bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in plastic bin");
        }
    }
}
