using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDDisplay : MonoBehaviour
{
    public GameObject hUDPanel;


    public void TurnOffOnPanel()
    {
        if (!hUDPanel.activeInHierarchy)
        {
            hUDPanel.SetActive(true);    
        }
        else if (hUDPanel.activeInHierarchy)
        {
            hUDPanel.SetActive(false);
        }
    }
}
