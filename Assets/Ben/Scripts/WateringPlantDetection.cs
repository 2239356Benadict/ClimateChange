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
        StartCoroutine(ActivateOfRain());
    }
    //public void OnTriggerStay(Collider other)
    //{
    //    if(other.gameObject.tag == "Water")
    //    {
    //        WaterPoured();
    //    }
    //}

    //public void WaterPoured()
    //{
    //    watered = true;
    //}

    //public void Update()
    //{
    //    ActivateCrop();
    //}
    //public void ActivateCrop()
    //{
    //    if (watered)
    //    {
    //        crop.SetActive(true);
    //    }
    //}

    IEnumerator ActivateOfRain()
    {
        yield return new WaitForSeconds(0.5f);
        crop.SetActive(true);
    }
}
