using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourTiltDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin;
    public GameObject streamPrefab;

    private bool isPouring;
    private Stream stream;


    private void Update()
    {
        bool pourChecking = CalaculateTheBottleTiltAngle() < pourThreshold;

        if(isPouring != pourChecking)
        {
            isPouring = pourChecking;
            if (isPouring)
            {
                StartPouring();
            }
            else
            {
                StopPouring();
            }
        }
    }

    public void StartPouring()
    {
        Debug.Log("Started Pouring");
        stream = CreateWaterStream();
        stream.BeginStream();
    }

    public void StopPouring()
    {
        stream.End();
        stream = null;
        Debug.Log("Stop Pouring");
    }

    public float CalaculateTheBottleTiltAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    public Stream CreateWaterStream()
    {
        GameObject stream = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return stream.GetComponent<Stream>();
    }
}
