using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverFadeOut : MonoBehaviour
{
    public float FadeOutTime = 1.5f ;
    public CanvasGroup canvasGroup;

    public void FadeOut()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();

        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / FadeOutTime;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}
