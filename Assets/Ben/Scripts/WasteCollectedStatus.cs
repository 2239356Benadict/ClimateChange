// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to check what scenario need to be loaded according to the number of wastes collected.

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

    public float loadScreenTime;
    public Light directionalLight;
    public LoadingScreenController loading;
    public float fadeInDelayTime;
    public void WasteCollectionStatus()
    {
        StartCoroutine(LoadingScreenTimer(fadeInDelayTime));

        if(collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true 
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            StartCoroutine(LoadingGoodScenario(loadScreenTime));
            //goodEnvironment = true;
            //goodScenario.SetActive(true);
            //endPanel.SetActive(true);
            //entryScenario.SetActive(false);
            //Debug.Log("Good Scenario");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            StartCoroutine(LoadingBadScenario(loadScreenTime));
            //badEnvironment = true;
            //badScenario.SetActive(true);
            //endPanel.SetActive(true);
            //entryScenario.SetActive(false);
            //Debug.Log(badScenario.activeInHierarchy);
            //Debug.Log("Worst Scenario");
        }
        else
        {
            StartCoroutine(LoadingAverageScenario(loadScreenTime));
            //AverageScenario();
            //endPanel.SetActive(true);
            //averageEnvironment = true;
            //entryScenario.SetActive(false);
            //Debug.Log("Average Scenario");
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

    IEnumerator LoadingScreenTimer(float fadeInDelayTime)
    {
        loading.FadeOut();
        yield return null; 
    }


    IEnumerator LoadingGoodScenario(float loadingDelayTime)
    {
        yield return new WaitForSeconds(loadingDelayTime);
        goodEnvironment = true;
        goodScenario.SetActive(true);
        endPanel.SetActive(true);
        entryScenario.SetActive(false);
        directionalLight.intensity = 1;
        yield return new WaitForSeconds(loadingDelayTime);
        loading.FadeIn();
        yield return null;
    }
    IEnumerator LoadingBadScenario(float loadingDelayTime)
    {
        yield return new WaitForSeconds(loadingDelayTime);
        badEnvironment = true;
        badScenario.SetActive(true);
        endPanel.SetActive(true);
        entryScenario.SetActive(false);
        directionalLight.intensity = 2;
        yield return new WaitForSeconds(loadingDelayTime);
        loading.FadeIn();
        Debug.Log(badScenario.activeInHierarchy);
        Debug.Log("Worst Scenario");
        yield return null;
    }
    IEnumerator LoadingAverageScenario(float loadingDelayTime)
    {
        yield return new WaitForSeconds(loadingDelayTime);
        AverageScenario();
        endPanel.SetActive(true);
        averageEnvironment = true;
        entryScenario.SetActive(false);
        directionalLight.intensity = 1.3f;
        yield return new WaitForSeconds(loadingDelayTime);
        loading.FadeIn();
        Debug.Log("Average Scenario");
        yield return null;
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
