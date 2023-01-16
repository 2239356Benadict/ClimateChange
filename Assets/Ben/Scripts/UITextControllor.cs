using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextControllor : MonoBehaviour
{
    public TextMeshProUGUI hUD_DisplayText;
    public TextMeshProUGUI hUD_ButtonText;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ButtonTextUpdate()
    {
        
    }
}
