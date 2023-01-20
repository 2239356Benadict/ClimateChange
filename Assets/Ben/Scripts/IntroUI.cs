using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroUI : MonoBehaviour
{
    [SerializeField]
    private int _clickCount;

    public TextMeshProUGUI introPanelText;
    public TextMeshProUGUI introPanelButtonText;

    public GameObject introPanel;

    private void Start()
    {
        ChangeText();
    }
    public void CLickCaseCount()
    {
        _clickCount++;
        ChangeText();
    }
    public void ChangeText()
    {
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
                introPanelButtonText.text = "play";
                break;
            case 3:
                introPanel.SetActive(false);
                break;
        }
    }
}
