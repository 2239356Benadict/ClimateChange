using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinForPaper : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            Debug.Log("Plastic waste in paper bin");
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            Debug.Log("Bio in paper bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in paper bin");
        }
    }
}
