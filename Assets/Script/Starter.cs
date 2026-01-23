using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Starter : MonoBehaviour
{
    public float delay = 1f;
    public UnityEvent onStart;

    private void Start()
    {
        StartCoroutine(StartAfterDelay());
    }

    private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        onStart.Invoke();
    }
}
