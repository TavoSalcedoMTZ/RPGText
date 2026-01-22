using UnityEngine;

public class PanelMove : MonoBehaviour
{
    [Header("Positions")]
    public Vector2 enterPos;
    public Vector2 exitPos;

    [Header("Tween")]
    public float moveTime = 0.4f;
    public LeanTweenType easeType = LeanTweenType.easeOutCubic;

    private RectTransform rectTransform;
    private bool isEntered;
    private int tweenId;
    public bool StartEnter;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {

        if (StartEnter)
        {
            SetExitImmediate();
        }
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
        MoveTo(enterPos);
    }

    public void ToggleExit()
    {
        if (!isEntered)
            return;

        isEntered = false;
        MoveTo(exitPos);
    }

    // =========================
    // CORE MOVE
    // =========================
    private void MoveTo(Vector2 targetPos)
    {
        LeanTween.cancel(tweenId);

        tweenId = LeanTween.move(rectTransform, targetPos, moveTime)
            .setEase(easeType)
            .id;
    }

    // =========================
    // IMMEDIATE
    // =========================
    public void SetEnterImmediate()
    {
        isEntered = true;
        rectTransform.anchoredPosition = enterPos;
    }

    public void SetExitImmediate()
    {
        isEntered = false;
        rectTransform.anchoredPosition = exitPos;
    }
}
