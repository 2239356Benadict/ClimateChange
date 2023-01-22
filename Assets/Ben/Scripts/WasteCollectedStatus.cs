using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteCollectedStatus : MonoBehaviour
{
    public BinForPlastic collectedPlasticWasteStatus;
    public BinForBio collectedBioWasteStatus;
    public BinForPaper collectedPaperWasteStatus;

    public GameObject goodScenario;
    public GameObject averageScenario;
    public GameObject badScenario;

    public GameObject entryScenario;

    public GameObject endPanel;

    public bool goodEnvironment;
    public bool averageEnvironment;
    public bool badEnvironment;

    public GameObject waterObject;
    public float riseSpeed;
    public float maxRise;
    public float minRise;

    public void WasteCollectionStatus()
    {
        if(collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true 
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            goodEnvironment = true;
            goodScenario.SetActive(true);
            endPanel.SetActive(true);
            entryScenario.SetActive(false);
            Debug.Log("Good Scenario");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            badEnvironment = true;
            badScenario.SetActive(true);
            endPanel.SetActive(true);
            entryScenario.SetActive(false);
            Debug.Log(badScenario.activeInHierarchy);
            Debug.Log("Worst Scenario");
        }
        else
        {
            AverageScenario();
            endPanel.SetActive(true);
            averageEnvironment = true;
            entryScenario.SetActive(false);
            Debug.Log("Average Scenario");
        }

        WaterLevelRise();
    }


    public void AverageScenario()
    {
        if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario1");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario2");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario3");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario3");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario3");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario3");
        }
    }




    private void Update()
    {
        //WaterLevelRise();
    }

    public void WaterLevelRise()
    {
        if (goodEnvironment)
        {
            if (waterObject.transform.position.y < maxRise)
            {
                waterObject.transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            }
        }
        else if (averageEnvironment)
        {
            if (waterObject.transform.position.y < minRise)
            {
                waterObject.transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            }
        }
        else if (badEnvironment)
        {
            if (waterObject.transform.position.y < minRise)
            {
                waterObject.transform.Translate(Vector3.down * riseSpeed * Time.deltaTime);
            }
        }
     
    }
}
