using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    #region parameter
    [SerializeField]
    private bool autostart = false;

    [SerializeField]
    private bool restart = false;

    [SerializeField]
    private float time = 1f;

    [SerializeField]
    private UnityEvent onTimeout;
    #endregion

    #region properties

    private float timeLeft;

    private bool timeOut = false;

    private bool isTimeRunning = false;

    #endregion

    #region methods

    public void SetTime(float _time)
    {
        time = _time;
    }

    public void SetRestart(bool value)
    {
        restart = value;
    }

    public void TimerStart()
    {
        timeLeft = time;
        timeOut = false;
        isTimeRunning = true;
    }

    public void TimerStop()
    {
        isTimeRunning = false;
    }

    public void TimerPause(bool pause)
    {
        isTimeRunning = pause;
    }

    public bool IsTimerRunning()
    {
        return isTimeRunning;
    }

    public void Start()
    {
        timeLeft = time;
        if (autostart) TimerStart();
    }

    #endregion
    void Update()
    {
        if (IsTimerRunning()) timeLeft -= Time.deltaTime;

        if (timeLeft <= 0 && !timeOut)
        {
            timeOut = true;
            TimerStop();

            onTimeout.Invoke();

            if (restart) TimerStart();
        }

    }
}
