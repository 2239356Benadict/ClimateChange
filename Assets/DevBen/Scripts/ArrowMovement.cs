// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used for the to and fro movement of a gameobject.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed;

    public float height = 0.5f;

    public Vector3 pos;

    private void Start()
    {
        pos = gameObject.transform.position;
    }
    void Update()
    {
        ToAndFroMovement();
    }

    /// <summary>
    /// Method for the movement of game object between two points.
    /// </summary>
    public void ToAndFroMovement()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
