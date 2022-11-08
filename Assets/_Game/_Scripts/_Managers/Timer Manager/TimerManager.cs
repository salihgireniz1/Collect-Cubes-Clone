using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static event Action OnTimesOut;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private float timerStartDuration;

    private bool canCount = false;
    private float duration;
    private float minutes;
    private float seconds;

    private void OnEnable()
    {
        LevelManager.OnTimerLevelGenerated += InitializeTimer;
        LevelManager.OnAILevelGenerated += InitializeTimer;
    }
    private void OnDisable()
    {
        LevelManager.OnTimerLevelGenerated -= InitializeTimer;
        LevelManager.OnAILevelGenerated -= InitializeTimer;
    }
    private void Update()
    {
        if (canCount) CountDown();
    }
    public void InitializeTimer(LevelInfoAsset asset)
    {
        duration = asset.TimerAsSeconds;
        StartCoroutine(StartCountDown());
    }
    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(timerStartDuration);
        timeText.enabled = true;
        canCount = true;
    }
    void HandleTimerComplete()
    {
        canCount = false;
        timeText.enabled = false;
        GameManager.Instance.HandleTimeOut();
        OnTimesOut?.Invoke();
    }
    public void CountDown()
    {
        if (duration < 0)
        {
            duration = 0;
            HandleTimerComplete();
            
        }
        else if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        minutes = (int)(duration / 60f);
        seconds = (int)(duration % 60f);
        timeText.text = minutes.ToString("f0").PadLeft(2, '0') + ":" + seconds.ToString("f0").PadLeft(2, '0');
    }
}
