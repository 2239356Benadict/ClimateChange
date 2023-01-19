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

    public GameObject endPanel;

    public bool goodEnvironment;
    public bool averageEnvironment;
    public bool badEnvironment;



    public void WasteCollectionStatus()
    {
        if(collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true 
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            goodEnvironment = true;
            //SceneManager.LoadScene(1);
            goodScenario.SetActive(true);
            endPanel.SetActive(true);

            Debug.Log("Good Scenario");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            badEnvironment = true;
            //SceneManager.LoadScene(3);
            badScenario.SetActive(false);
            endPanel.SetActive(true);

            Debug.Log("Worst Scenario");
        }
        else
        {
            AverageScenario();
            endPanel.SetActive(true);
            averageEnvironment = true;
            Debug.Log("Average Scenario");
        }
    }


    public void AverageScenario()
    {
        if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            //SceneManager.LoadScene(2);
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario1");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            //SceneManager.LoadScene(2);
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario2");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            //SceneManager.LoadScene(2);
            averageScenario.SetActive(true);
            Debug.Log("Average Scenario3");
        }
    }

    public GameObject waterObject;
    public float riseSpeed;
    public float maxRise;
    public float minRise;


    private void Update()
    {
        WaterLevelRise();
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
     
    }
}
