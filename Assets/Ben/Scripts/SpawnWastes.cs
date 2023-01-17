using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWastes : MonoBehaviour
{
    public GameObject wasteObject;
    public Material[] wasteGOMaterial;
    public int numberOfWaste;
    public int maxNumberOfWaste;


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
            wasteObject.GetComponent<Renderer>().material = wasteGOMaterial[randomMaterial];
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
            Vector3 position = new(Random.Range(1.0f, 3.0F), 0.5f, Random.Range(18.0F, 20.0F));
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
