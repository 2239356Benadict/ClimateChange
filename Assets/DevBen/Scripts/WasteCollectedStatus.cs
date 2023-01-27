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

    /// <summary>
    /// This method is used to identify the scenario to be loaded according to the number of wastes collected.
    /// </summary>
    public void WasteCollectionStatus()
    {
        StartCoroutine(LoadingScreenTimer(fadeInDelayTime));
        // Checking the boolean values
        if(collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true 
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            StartCoroutine(LoadingGoodScenario(loadScreenTime));
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            StartCoroutine(LoadingBadScenario(loadScreenTime));
        }
        else
        {
            StartCoroutine(LoadingAverageScenario(loadScreenTime));
        }

        WaterLevelRise();
    }

    /// <summary>
    /// Method to check different options for average scenario
    /// </summary>
    public void AverageScenario()
    {
        if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            averageScenario.SetActive(true);
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            averageScenario.SetActive(true);     
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            averageScenario.SetActive(true);           
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            averageScenario.SetActive(true);
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            averageScenario.SetActive(true);
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            averageScenario.SetActive(true);
        }
    }

    /// <summary>
    /// Coroutine to delay fade out of loading screen after finishing the wastes.
    /// </summary>
    /// <param name="fadeInDelayTime"></param>
    /// <returns></returns>
    IEnumerator LoadingScreenTimer(float fadeInDelayTime)
    {
        loading.FadeOut();
        yield return null; 
    }

    /// <summary>
    /// Coroutine to load the good scenario with a slight delay
    /// </summary>
    /// <param name="loadingDelayTime"></param>
    /// <returns></returns>
    IEnumerator LoadingGoodScenario(float loadingDelayTime)
    {
        // wait for a period of time before start.
        yield return new WaitForSeconds(loadingDelayTime);
        goodEnvironment = true;
        goodScenario.SetActive(true);
        endPanel.SetActive(true);
        entryScenario.SetActive(false);
        directionalLight.intensity = 1;
        WaterLevelRise();
        yield return new WaitForSeconds(loadingDelayTime);
        loading.FadeIn();
        yield return null;
    }

    /// <summary>
    /// Coroutine to load the bad scenario with a slight delay
    /// </summary>
    /// <param name="loadingDelayTime"></param>
    /// <returns></returns>
    IEnumerator LoadingBadScenario(float loadingDelayTime)
    {
        yield return new WaitForSeconds(loadingDelayTime);
        badEnvironment = true;
        badScenario.SetActive(true);
        endPanel.SetActive(true);
        entryScenario.SetActive(false);
        directionalLight.intensity = 2;
        WaterLevelRise();
        yield return new WaitForSeconds(loadingDelayTime);
        loading.FadeIn();
        yield return null;
    }

    /// <summary>
    /// Coroutine to load the average scenario with slight delay
    /// </summary>
    /// <param name="loadingDelayTime"></param>
    /// <returns></returns>
    IEnumerator LoadingAverageScenario(float loadingDelayTime)
    {
        yield return new WaitForSeconds(loadingDelayTime);
        AverageScenario();
        endPanel.SetActive(true);
        averageEnvironment = true;
        entryScenario.SetActive(false);
        directionalLight.intensity = 1.3f;
        WaterLevelRise();
        yield return new WaitForSeconds(loadingDelayTime);
        loading.FadeIn();        
        yield return null;
    }

    /// <summary>
    /// Method to increase or decrease the water level according to the scenario.
    /// </summary>
    public void WaterLevelRise()
    {
        if (goodEnvironment)
        {
            if (waterObject.transform.position.y < maxRise)
            {
                // moving the gameobject along y axis, i.e. upwards
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
