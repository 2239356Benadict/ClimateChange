using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnOutputController : MonoBehaviour
{
    public GameObject badScenarioObjects;
    public GameObject entryEnvironmentObjects;
    public GameObject endPanel;
    public WasteCollectedStatus collectedStatus;

    public InMemoryVariableStorage yarnMemory;

    public void Update()
    {
        BadScenario();
    }


    [YarnCommand("BadScenario")]
    public void BadScenario()
    {
        bool answerNo;
        yarnMemory.TryGetValue("$notReady", out answerNo);


        if (answerNo)
        {
            //collectedStatus.WasteCollectionStatus();
            badScenarioObjects.SetActive(true);
            entryEnvironmentObjects.SetActive(false);
            endPanel.SetActive(true);
        }
    }
}
