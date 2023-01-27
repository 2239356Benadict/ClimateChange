using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDDisplay : MonoBehaviour
{
    public GameObject hUDPanel;

    /// <summary>
    /// Method to activate or deactivate the gameobject according to the active status in heirarchy.
    /// </summary>
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
