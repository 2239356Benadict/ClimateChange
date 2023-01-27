// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to control the alpha value of the material of a game object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurValue : MonoBehaviour
{
    public Material eyeBlurMaterial;


    public void BlurToClearEffect()
    {

        Color alphaColor = eyeBlurMaterial.color;
        alphaColor.a -= 0.1f * Time.deltaTime;
        eyeBlurMaterial.color = alphaColor;
    }

    private void Update()
    {
        BlurToClearEffect();
    }
}
