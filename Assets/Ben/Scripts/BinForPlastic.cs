// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to count the waste put into the bin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinForPlastic : MonoBehaviour
{
    [SerializeField]
    private int plasticWasteCount = 0;

    public int totalPlastiWateToReceive;
    public bool isAllPlasticwasteCollected = false;
    public bool somePlasticwasteCollected = false;
    public bool noPlasticwasteCollected = false;

    public TextMeshProUGUI platicCount;
    
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
            plasticWasteCount++;
            platicCount.text = plasticWasteCount.ToString();
            PlasticCollectionStatus();
            Debug.Log("Plastic waste in plastic bin " + plasticWasteCount);
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            Debug.Log("Bio in plastic bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in plastic bin");
        }
    }

    public void Update()
    {
        //PlasticCollectionStatus();
    }

    public void PlasticCollectionStatus()
    {
        if (plasticWasteCount == totalPlastiWateToReceive)
        {
            isAllPlasticwasteCollected = true;
            somePlasticwasteCollected = false;
            noPlasticwasteCollected = false;
        }
        else if (plasticWasteCount < totalPlastiWateToReceive && plasticWasteCount >= (totalPlastiWateToReceive / 2))
        {
            isAllPlasticwasteCollected = false;
            somePlasticwasteCollected = true;
            noPlasticwasteCollected = false;
        }
        else if(plasticWasteCount < (totalPlastiWateToReceive / 2))
        {
            isAllPlasticwasteCollected = false;
            somePlasticwasteCollected = false;
            noPlasticwasteCollected = true;
        }
        //hUDTextControllor.hUD_DisplayText.text = hUDTextControllor.hUD_DisplayText.text + "Number of Plastic Waste collected: " + plasticWasteCount + "\n";
    }
}
