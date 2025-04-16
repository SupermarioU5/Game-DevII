using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public static SpeedrunTimer instance;

    public TextMeshProUGUI timeDisplay;
    public bool isRunning = false;
    private float startTime;
    private float pausedTime;

    void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start the timer
    public void StartTimer()
    {
        isRunning = true;
        startTime = Time.time;
        pausedTime = 0;
    }

    // Stop the timer
    public void StopTimer()
    {
        isRunning = false;
        pausedTime = Time.time - startTime;
    }

    // Resume the timer
    public void ResumeTimer()
    {
        isRunning = true;
        startTime = Time.time - pausedTime;
        pausedTime = 0;
    }

    void Update()
    {
        if (isRunning)
        {
            float currentTime = Time.time - startTime;
            timeDisplay.text = FormatTime(currentTime);
        }
        else
        {
            float totalTime = pausedTime;
            timeDisplay.text = FormatTime(totalTime);
        }
    }

    // Helper function to format the time (e.g., 0:00:00.000)
    private string FormatTime(float seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        return string.Format("{0:D2}:{1:D2}.{2:D2}", time.Minutes, time.Seconds, (time.Milliseconds/10) %100);
    }
    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}