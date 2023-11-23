using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public event EventHandler OnTaskFinished;
    public bool IsDone { get; private set; }
    [HideInInspector] public bool IsInProgress;

    [Tooltip("In Seconds")]
    [Range(0.5f, 15f)]
    [SerializeField] float timeNeeded;

    float progress;

    private void Start()
    {
        IsInProgress = false;
    }

    private void Update()
    {
        if (IsInProgress)
        {
            progress += Time.deltaTime;
            if (progress >= timeNeeded)
            {
                IsDone = true;
                OnTaskFinished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
