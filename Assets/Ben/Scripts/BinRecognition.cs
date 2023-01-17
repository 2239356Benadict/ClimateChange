using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinRecognition : MonoBehaviour
{
    public GameObject[] binTargets;

    public void OnTriggerEnter(Collider other)
    {
        foreach(GameObject bin in binTargets)
        {
            Debug.Log(bin.tag);
            if(bin.tag == "PlasticBin" && other.gameObject.tag == "Plastic")
            {
                Debug.Log("Plastic waste in plastic bin");
            }
            else if(bin.tag == "BioBin" && other.gameObject.tag == "BioDegradable")
            {
                Debug.Log("Bio in bio bin");
            }
            else if(bin.tag == "PaperBin" && other.gameObject.tag == "Paper")
            {
                Debug.Log("Paper in paper bin");
            } 
        }
    }

}
