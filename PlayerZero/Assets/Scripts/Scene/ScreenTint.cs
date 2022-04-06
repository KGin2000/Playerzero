using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ScreenTint : MonoBehaviour
{
    [SerializeField] Color unTintedColor;
    [SerializeField] Color tintedColor;
    float f;
    [SerializeField] float speed;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Tint()
    {
        EventHandler.CallBeforeSceneUnloadFadeOutEvent();   //Stop Move
        StopAllCoroutines();
        f = 0f;
        StartCoroutine(TintScreen());
    }

    public void UnTint()
    {
        EventHandler.CallAfterSceneLoadFadeInEvent();       //Can Move
        StopAllCoroutines();
        f = 0f;
        StartCoroutine(UnTintScreen());
    }

    private IEnumerator TintScreen()
    {
        while(f < 1f)
        {
            f += Time.deltaTime;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(unTintedColor, tintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator UnTintScreen()
    {
        while(f < 1f)
        {
            f += Time.deltaTime;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(tintedColor, unTintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }
}
