using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinForBio : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            Debug.Log("Plastic waste in bio bin");
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            Debug.Log("Bio in bio bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in bio bin");
        }
    }
}
