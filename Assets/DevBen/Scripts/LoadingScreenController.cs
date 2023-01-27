// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to control loading screen.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenController : MonoBehaviour
{
    public Renderer screenRenderer;

    public float fadeDuration;
    public Color fadeColor;

    public bool fadeOnStart;
    private void Start()
    {
        //accessing the gameobject renderer
        screenRenderer = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }
    /// <summary>
    /// Method to decrease the alpha value,
    /// </summary>
    public void FadeIn()
    {
        Fade(1, 0);
    }
    /// <summary>
    /// Method to increase the alpha value.
    /// </summary>
    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    /// <summary>
    /// Coroutine to change the alpha value of a material 
    /// </summary>
    /// <param name="alphaIn"></param>
    /// <param name="alphaOut"></param>
    /// <returns></returns>
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor1 = fadeColor;
            newColor1.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            //accessing the color variable of the shader.
            screenRenderer.material.SetColor("_BaseColor", newColor1);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        screenRenderer.material.SetColor("_Color", newColor2);
    }
}
