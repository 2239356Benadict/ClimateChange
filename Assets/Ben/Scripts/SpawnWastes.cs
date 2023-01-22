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
    public void SpawnWastesRandomly()
    {
        foreach(Material material in wasteGOMaterial)
        {
            int randomMaterial = Random.Range(0, wasteGOMaterial.Length);
            //wasteObject.GetComponent<Renderer>().material = wasteGOMaterial[randomMaterial];
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
            Vector3 position = new(Random.Range(min_X_Value, max_X_Value), 0.4f, Random.Range(min_Z_Value, max_Z_Value));
            Instantiate(wasteObject, position, Quaternion.identity);
            Debug.Log(numberOfWaste);
        }
        else
        {
            return;
        }
    }
    #endregion
}
