using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;
    public float duration = 120f; // Durasi timer dalam detik (2 menit)
    private float timer;
    private bool isTimerRunning = false;

    [SerializeField] LeaderboardManager leaderboardManager;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI(timer);

            if (timer <= 0f)
            {
                isTimerRunning = false;
                timer = 0f;
                leaderboardManager.DisplayLeaderboard();
            }
        }
    }

    public void StartTimer()
    {
        timer = duration;
        isTimerRunning = true;
    }

    void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
