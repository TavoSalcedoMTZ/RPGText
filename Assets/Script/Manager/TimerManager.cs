using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    public float timerDuration = 8f;
    private float timer;
    public bool isTimerRunning = false;

    public UnityEvent onTimerEnd;     
    public UnityEvent onTimerSaved;   

    private Coroutine timerCoroutine;
    private bool wasCancelled;


    public void StartTimerManager()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        wasCancelled = false;
        timerCoroutine = StartCoroutine(StartTimer());
    }


    public void StopTimer()
    {
        if (!isTimerRunning)
            return;

        wasCancelled = true;

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        isTimerRunning = false;
        onTimerSaved.Invoke();
    }


    private IEnumerator StartTimer()
    {
        timer = timerDuration;
        isTimerRunning = true;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        isTimerRunning = false;
        timerCoroutine = null;

        if (!wasCancelled)
            onTimerEnd.Invoke();
    }


    public float GetNormalizedTime()
    {
        return timer / timerDuration;
    }
}
