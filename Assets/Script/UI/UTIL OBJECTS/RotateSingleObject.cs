using UnityEngine;

public class RotateSingleObject : MonoBehaviour
{
    public float speed = 180f; 

    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.Rotate(0f, 0f, -speed * Time.deltaTime);
    }
}