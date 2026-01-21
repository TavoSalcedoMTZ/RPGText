using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct HoverObjectSettings
{
    public Color color;
    public float scale;
}

public class HoverSelected : MonoBehaviour
{
    public HoverObjectSettings unHoverSettings;
    public HoverObjectSettings hoverSettings;

    public bool autoStartUnHover = true;

    private Graphic graphic;
    private RectTransform rectTransform;

    void Awake()
    {
        graphic = GetComponent<Graphic>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        if (autoStartUnHover)
            AutoStartUnHover();
    }

    public void AutoStartUnHover()
    {
        if (graphic != null)
            unHoverSettings.color = graphic.color;

        if (rectTransform != null)
            unHoverSettings.scale = rectTransform.localScale.x;
    }

    public void SetHover()
    {
        if (graphic != null)
            graphic.color = hoverSettings.color;

        rectTransform.localScale = Vector3.one * hoverSettings.scale;
    }

    public void SetUnHover()
    {
        if (graphic != null)
            graphic.color = unHoverSettings.color;

        rectTransform.localScale = Vector3.one * unHoverSettings.scale;
    }
}
