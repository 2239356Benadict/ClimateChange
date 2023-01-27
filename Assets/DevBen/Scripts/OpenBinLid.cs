using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBinLid : MonoBehaviour
{
    public GameObject binLid;
    public float speed;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            binLid.transform.Rotate(Vector3.up * speed *Time.deltaTime, 90f);
        }
    }
}
