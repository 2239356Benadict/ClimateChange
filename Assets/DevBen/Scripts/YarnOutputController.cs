// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to access the yarn spinner.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnOutputController : MonoBehaviour
{
    public GameObject badScenarioObjects;
    public GameObject entryEnvironmentObjects;
    public GameObject endPanel;
    public GameObject hudPanel;
    public WasteCollectedStatus collectedStatus;

    public InMemoryVariableStorage yarnMemory;

    public void Update()
    {
        BadScenario();
    }

    /// <summary>
    /// Method to check the boolean value for Badscenario to load according to the user feedback.
    /// </summary>

    [YarnCommand("Bad_Scenario")]
    public void BadScenario()
    {
        bool answerNo;
        //get the value of the string from yarn script.
        yarnMemory.TryGetValue("$notReady", out answerNo);
        Debug.Log(answerNo);
        if (answerNo)
        {
            //gameobjects are set to active and deactive state.
            badScenarioObjects.SetActive(true);
            entryEnvironmentObjects.SetActive(false);
            hudPanel.SetActive(false);
            endPanel.SetActive(true);
        }
    }
}
