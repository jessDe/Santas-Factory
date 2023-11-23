using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event EventHandler OnTimerTrigger;

    [Tooltip("In Seconds")]
    [Range(1f, 10f)]
    [SerializeField] float delayTime;

    Coroutine timerCoroutine;

    public void StartTimer(float? delayInSeconds = null)
    {
        timerCoroutine = StartCoroutine(StartTime(delayInSeconds ?? delayTime));
    }

    public void RestartTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
    }

    private IEnumerator StartTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnTimerTrigger?.Invoke(this, EventArgs.Empty);
    }
}
