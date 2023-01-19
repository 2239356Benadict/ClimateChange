using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public GameObject waterObject;
    public float riseSpeed;
    public float maxRise;


    private void Update()
    {
        WaterLevelRise();
    }

    public void WaterLevelRise()
    {
        if(waterObject.transform.position.y < maxRise)
        {
            waterObject.transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
        }
        else
        {
            return;
        }    
    }
}
