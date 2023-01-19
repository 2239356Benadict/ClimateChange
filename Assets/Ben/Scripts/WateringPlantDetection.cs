using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringPlantDetection : MonoBehaviour
{
    public bool watered;
    public GameObject crop;

    private void Start()
    {
        watered = false;
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            WaterPoured();
            crop.SetActive(true);
        }
    }

    public void WaterPoured()
    {
        watered = true;
    }
}
