// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to count the waste put into the bin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinForBio : MonoBehaviour
{
    [SerializeField]
    private int bioWasteCount = 0;
    public int totalBioWastetoReceive;

    public bool isAllBioWasteCollected = false;
    public bool someBioWasteCollected = false;
    public bool noBioWasteCollected = false;

    public TextMeshProUGUI bioCount;

    [SerializeField]
    private UITextControllor hUDTextControllor;


    private void Start()
    {
        hUDTextControllor = GameObject.FindGameObjectWithTag("GameController").GetComponent<UITextControllor>();

    }

    /// <summary>
    /// Checks the game object colliding with this game object.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            
            Debug.Log("Plastic waste in bio bin "+ bioWasteCount);
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            bioWasteCount++;
            bioCount.text = bioWasteCount.ToString();
            BioWasteCollectionStatus();
            Debug.Log("Bio in bio bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in bio bin");
        }
    }


    /// <summary>
    /// Method to check the boolean according to the number of wastes collected.
    /// </summary>
    public void BioWasteCollectionStatus()
    {
        if (bioWasteCount == totalBioWastetoReceive)
        {
            isAllBioWasteCollected = true;
            someBioWasteCollected = false;
            noBioWasteCollected = false;
        }
        else if(bioWasteCount < totalBioWastetoReceive && bioWasteCount >= (totalBioWastetoReceive/2))
        {
            isAllBioWasteCollected = false;
            someBioWasteCollected = true;
            noBioWasteCollected = false;
        }
        else if(bioWasteCount < (totalBioWastetoReceive / 2))
        {
            isAllBioWasteCollected = false;
            someBioWasteCollected = false;
            noBioWasteCollected = true;
        }

        //hUDTextControllor.hUD_DisplayText.text = hUDTextControllor.hUD_DisplayText.text + "Number of Food Waste collected: " + bioWasteCount + "\n";
    }
}
