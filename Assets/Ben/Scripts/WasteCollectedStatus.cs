using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCollectedStatus : MonoBehaviour
{
    public BinForPlastic collectedPlasticWasteStatus;
    public BinForBio collectedBioWasteStatus;
    public BinForPaper collectedPaperWasteStatus;
    private bool plasticWasteStatus;
    private bool bioWasteStatus;
    private bool paperWasteStatus;
    public void WasteCollectionStatus()
    {
        if(collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == true 
            && collectedPaperWasteStatus.isAllpaperWasteCollected == true)
        {
            Debug.Log("Good Scenario");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
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
            Debug.Log("Worst Scenario1");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == true && collectedBioWasteStatus.isAllBioWasteCollected == false
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            Debug.Log("Worst Scenario2");
        }
        else if (collectedPlasticWasteStatus.isAllPlasticwasteCollected == false && collectedBioWasteStatus.isAllBioWasteCollected == true
            && collectedPaperWasteStatus.isAllpaperWasteCollected == false)
        {
            Debug.Log("Worst Scenario3");
        }
    }
}
