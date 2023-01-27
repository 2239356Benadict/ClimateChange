// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to spawn wastes at provided X&Z positions values randomly.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWastes : MonoBehaviour
{
    public GameObject wasteObject;
    public Material[] wasteGOMaterial;
    public int numberOfWaste;
    public int maxNumberOfWaste;

    public float min_X_Value;
    public float max_X_Value;
    public float min_Z_Value;
    public float max_Z_Value;


    #region Monobehaviour Methods
    private void Update()
    {
        SpawnCube();
    }
    #endregion


    #region Private Methods

    /// <summary>
    /// Method to spawn waste object at random position for a given range of values.
    /// </summary>
    public void SpawnWastesRandomly()
    {
        foreach(Material material in wasteGOMaterial)
        {
            int randomMaterial = Random.Range(0, wasteGOMaterial.Length);
            //randomly assign the material
            wasteObject.GetComponentInChildren<Renderer>().material = wasteGOMaterial[randomMaterial];
        }
        numberOfWaste++;
    }

    /// <summary>
    /// Spawn the waste gameobject for the integer value of maxNumberOfWaste
    /// </summary>
    public void SpawnCube()
    {
        if (numberOfWaste < maxNumberOfWaste)
        {
            SpawnWastesRandomly();
            //randomising the position for given values
            Vector3 position = new(Random.Range(min_X_Value, max_X_Value), 0.4f, Random.Range(min_Z_Value, max_Z_Value));
            //spawning the gameobject.
            Instantiate(wasteObject, position, Quaternion.identity);
        }
        else
        {
            return;
        }
    }
    #endregion
}
