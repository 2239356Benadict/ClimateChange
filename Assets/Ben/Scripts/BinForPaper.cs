// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to count the waste put into the bin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinForPaper : MonoBehaviour
{
    [SerializeField]
    private int paperWasteCount = 0;
    public int totalPaperWasteToReceive;

    public bool isAllpaperWasteCollected = false;
    public bool somepaperWasteCollected = false;
    public bool noPaperWastesCollected = false;

    public TextMeshProUGUI paperCount;

    [SerializeField]
    private UITextControllor hUDTextControllor;


    private void Start()
    {
        hUDTextControllor = GameObject.FindGameObjectWithTag("GameController").GetComponent<UITextControllor>();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            
            Debug.Log("Plastic waste in paper bin ");
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            
            Debug.Log("Bio in paper bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            paperWasteCount++;
            paperCount.text = "number paper wastes collected: " + paperWasteCount.ToString();
            PaperCollectionStatus();
            Debug.Log("Paper in paper bin");
        }
    }

    public void Update()
    {
        //PaperCollectionStatus();
    }

    public void PaperCollectionStatus()
    {
        
        if(paperWasteCount == totalPaperWasteToReceive)
        {
            isAllpaperWasteCollected = true;
            somepaperWasteCollected = false;
            noPaperWastesCollected = false;
        }
        else if (paperWasteCount < totalPaperWasteToReceive && paperWasteCount >= (totalPaperWasteToReceive / 2))
        {
            isAllpaperWasteCollected = false;
            somepaperWasteCollected = true;
            noPaperWastesCollected = false;
        }
        else if (paperWasteCount < (totalPaperWasteToReceive / 2))
        {
            isAllpaperWasteCollected = false;
            somepaperWasteCollected = false;
            noPaperWastesCollected = true;
        }
        //hUDTextControllor.hUD_DisplayText.text = hUDTextControllor.hUD_DisplayText.text + "Number of Paper Waste collected: " + paperWasteCount + "\n";
    }
}
