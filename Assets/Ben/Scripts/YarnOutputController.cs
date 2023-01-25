using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnOutputController : MonoBehaviour
{
    public GameObject badScenario;
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
        string playerReply;
        yarnMemory.TryGetValue("$notReadyToProceed", out playerReply);
        Debug.Log(playerReply);
        Debug.Log(answerNo);

        if (playerReply == "True")
        {
            badScenario.SetActive(true);
            entryEnvironmentObjects.SetActive(false);
            endPanel.SetActive(true);
            Debug.Log(playerReply);
        }
    }
}
