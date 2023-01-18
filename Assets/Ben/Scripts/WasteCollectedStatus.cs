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

    private bool plasticWasteStatus;
    private bool bioWasteStatus;
    private bool paperWasteStatus;
    public void WasteCollectionStatus()
    {
        if(collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true 
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            //SceneManager.LoadScene(1);
            goodScenario.SetActive(true);
            Debug.Log("Good Scenario");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            //SceneManager.LoadScene(3);
            badScenario.SetActive(false);
            Debug.Log("Worst Scenario");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false || collectedBioWasteStatus.isAllBioWasteCollected == false
            || collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            AverageScenario();
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

}
