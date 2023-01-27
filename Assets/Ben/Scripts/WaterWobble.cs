// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to count the waste put into the bin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWobble : MonoBehaviour
{
    Renderer rend;
    Vector3 lastPos;
    Vector3 velocity;
    Vector3 lastRot;
    Vector3 angularVelocity;
    public float maxWobble = 0.03f;
    public float wobbleSpeed = 1f;
    public float recovery = 1f;
    float wobbleAmountX = 1f;
    float wobbleAmountToAddX = 1f;
    float wobbleAmountZ = 1f;
    float wobbleAmountToAddZ = 1f;
    float pulse;
    float time = 0.5f;
  

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }



    /// <summary>
    /// Method to adjust the material from a customized shader to show liquid effect in a container.
    /// </summary>
    public void WobbleEffect()
    {
        time += Time.deltaTime;

        //decrease wobble over time

        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * (recovery));
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * (recovery));

        pulse = 2 * Mathf.PI * wobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        rend.material.SetFloat("_WobbleX", wobbleAmountX);
        rend.material.SetFloat("_WobbleZ", wobbleAmountZ);

        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;

        wobbleAmountToAddX += Mathf.Clamp(velocity.x + (angularVelocity.z * 0.2f) * maxWobble, -maxWobble, maxWobble);
        wobbleAmountToAddZ += Mathf.Clamp(velocity.z + (angularVelocity.x * 0.2f) * maxWobble, -maxWobble, maxWobble);

        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;
    }
}
