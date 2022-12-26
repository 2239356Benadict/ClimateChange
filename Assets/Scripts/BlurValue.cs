using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurValue : MonoBehaviour
{
    public Material eyeBlurMaterial;
    public GameObject blurObject;

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
