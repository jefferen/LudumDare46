using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    public static FadeMaterial fade;
    public float fadeDuration;
    public MeshRenderer mat;

    void Awake()
    {
        fade = this;
    }

    public IEnumerator Fade(float fadeDuration, Image mat, bool fadeInTrue) // it does get the instance and doesn´t affect all objects with the material!!!!
    {
        if (!fadeInTrue) // fade out
        {
            while (mat.color.a >= 0.01f)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - ((0.01f) / fadeDuration));
                yield return new WaitForSeconds(0.01f);
            }
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0);
            yield return new WaitForEndOfFrame();
        }
        else
        {
            while (mat.color.a <= 0.98f) // fade in
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + ((0.01f) / fadeDuration));
                yield return new WaitForSeconds(0.01f);
            }
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1);
            yield return new WaitForEndOfFrame();
        }

    }
}
