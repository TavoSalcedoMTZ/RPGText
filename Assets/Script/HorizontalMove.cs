using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [Header("Positions (X)")]
    public float enterX = -549f;
    public float exitX = -1325f;

    [Header("Tween")]
    public float moveTime = 0.4f;
    public LeanTweenType easeType = LeanTweenType.easeOutCubic;

    private RectTransform rectTransform;
    private bool isEntered;
    private int tweenId;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        SetExitImmediate();
    }


    public void Toggle()
    {
        if (isEntered)
            ToggleExit();
        else
            ToggleEnter();
    }


    public void ToggleEnter()
    {
        if (isEntered)
            return;

        isEntered = true;
        MoveToX(enterX);
    }


    public void ToggleExit()
    {
        if (!isEntered)
            return;

        isEntered = false;
        MoveToX(exitX);
    }


    private void MoveToX(float targetX)
    {
        LeanTween.cancel(tweenId);

        tweenId = LeanTween.moveX(rectTransform, targetX, moveTime)
            .setEase(easeType)
            .id;
    }

    // =========================
    // IMMEDIATE (NO TWEEN)
    // =========================
    public void SetEnterImmediate()
    {
        isEntered = true;
        rectTransform.anchoredPosition =
            new Vector2(enterX, rectTransform.anchoredPosition.y);
    }

    public void SetExitImmediate()
    {
        isEntered = false;
        rectTransform.anchoredPosition =
            new Vector2(exitX, rectTransform.anchoredPosition.y);
    }
}