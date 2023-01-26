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


    [YarnCommand("Bad_Scenario")]
    public void BadScenario()
    {
        bool answerNo;
        yarnMemory.TryGetValue("$notReady", out answerNo);
        Debug.Log(answerNo);
        if (answerNo)
        {
            //collectedStatus.WasteCollectionStatus();
            badScenarioObjects.SetActive(true);
            entryEnvironmentObjects.SetActive(false);
            hudPanel.SetActive(false);
            endPanel.SetActive(true);
        }
    }
}
