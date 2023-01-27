// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to Quit the application.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    /// <summary>
    /// Method to quit application
    /// </summary>
    public void QuitTheApplication()
    {
        Application.Quit();
    }
}
