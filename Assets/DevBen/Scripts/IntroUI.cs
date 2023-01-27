// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to change the text dynamically and add functions to the button game object.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Management;
using UnityEngine.XR.Interaction.Toolkit;

public class IntroUI : MonoBehaviour
{
    [SerializeField]
    private int _clickCount;

    public TextMeshProUGUI introPanelText;
    public TextMeshProUGUI introPanelButtonText;
    public GameObject introPanel;

    public ContinuousMoveProviderBase continuousMoveXR;
    public Button hudDoneButton;
    private void Start()
    {
        ChangeText();
    }
    public void CLickCaseCount()
    {
        //incrementing the integer value by one.
        _clickCount++;
        ChangeText();
    }

    // Method to chnage the texts dynamically according to the clickcount integer value.
    public void ChangeText()
    {
        //switching the case state
        switch (_clickCount)
        {
            default:
                introPanelText.text = "welcome to the CLEAN!";
                introPanelButtonText.text = "next";
                break;
            case 1:
                introPanelText.text = "use right controller to rotate around.";
                introPanelButtonText.text = "next";
                break;
            case 2:
                introPanelText.text = "use left controller to move around.";
                introPanelButtonText.text = "next";
                break;
            case 3:
                introPanelText.text = "click on the status button on left hand.";
                introPanelButtonText.text = "play";
                break;
            case 4:
                continuousMoveXR.enabled = true;

                introPanel.SetActive(false);
                break;
        }
    }
}
