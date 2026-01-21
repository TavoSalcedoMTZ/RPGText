using UnityEngine;
using UnityEngine.Events;
public class DebugEvent : MonoBehaviour
{
    public UnityEvent onDKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            onDKeyPressed.Invoke();
        }
    }
}
