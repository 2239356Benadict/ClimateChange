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
                introPanelText.text = "Welcome to the IslandLearn!";
                introPanelButtonText.text = "continue";
                break;
            case 1:
                introPanelText.text = "please use right controller to rotate & left controller to move around.";
                introPanelButtonText.text = "play";
                break;
            case 2:
                introPanel.SetActive(false);
                break;
        }
    }
}
