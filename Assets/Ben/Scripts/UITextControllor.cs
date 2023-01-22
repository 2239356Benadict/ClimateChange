using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextControllor : MonoBehaviour
{
    public TextMeshProUGUI hUD_DisplayText;
    public TextMeshProUGUI hUD_ButtonText;
    public int clickCount;
    public WasteCollectedStatus collectedStatus;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        ButtonTextUpdate();
    }


    public void ButtonClickCOunt()
    {
        clickCount++;
        Debug.Log("Click count UI Text Controller: " + clickCount);
        ButtonTextUpdate();
    }
    

    public void ButtonTextUpdate()
    {
        switch (clickCount)
        {
            case 2:
                collectedStatus.WasteCollectionStatus();
                Debug.Log("Click count UI Text Controller: " + clickCount);
                Debug.Log("Enable Scenario!!!");
                break;
            case 1:
                hUD_ButtonText.text = "DONE";
                Debug.Log("Click count UI Text Controller: " + clickCount);
                break;
            default:
                hUD_DisplayText.text = "check here for the waste collected status. once finish the collection press 'DONE' in the next screen.";
                hUD_ButtonText.text = "OK";
                break;
        }
    }
}
