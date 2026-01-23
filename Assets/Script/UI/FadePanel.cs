using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image panelFade;
    private Coroutine fadeCoroutine;

    [Header("Fade Settings")]
    public float fadeTime = 1f;

    private void Start()
    {
        panelFade = GetComponent<Image>();
    }

    public void FadeIn()
    {
        StartFade(1f);
        panelFade.raycastTarget=true;
    }

    public void FadeOut()
    {
        StartFade(0f);
        panelFade.raycastTarget = false;
    }

    private void StartFade(float targetAlpha)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(targetAlpha));
    }

    private IEnumerator FadeRoutine(float target)
    {
        float startAlpha = panelFade.color.a;
        float time = 0f;

        Color color = panelFade.color;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            float t = time / fadeTime;

            color.a = Mathf.Lerp(startAlpha, target, t);
            panelFade.color = color;

            yield return null;
        }

        color.a = target;
        panelFade.color = color;
        fadeCoroutine = null;
    }
}
