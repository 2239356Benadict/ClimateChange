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

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void ButtonClickCOunt()
    {
        clickCount++;
        Debug.Log(clickCount);
        //ButtonTextUpdate();  //if the performance is low use the method here.
    }
    private void Update()
    {
        ButtonTextUpdate();
    }

    public void ButtonTextUpdate()
    {
        switch (clickCount)
        {
            case 2:
                print("Grog SMASH!");
                break;
            case 1:
                hUD_ButtonText.text = "DONE";
                break;
            default:
                hUD_DisplayText.text = "check the waste collected status";
                hUD_ButtonText.text = "OK";
                break;
        }
    }
}
