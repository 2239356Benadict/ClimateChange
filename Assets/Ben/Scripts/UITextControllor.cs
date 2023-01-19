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
 
        ButtonTextUpdate();
    }
    

    public void ButtonTextUpdate()
    {
        switch (clickCount)
        {
            case 2:
                collectedStatus.WasteCollectionStatus();
                break;
            case 1:
                hUD_ButtonText.text = "DONE";
                hUD_DisplayText.text = "";
                break;
            default:
                hUD_DisplayText.text = "check the waste collected status";
                hUD_ButtonText.text = "OK";
                break;
        }
    }
}
