using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f; // Total game time in seconds
    private float currentTime;
    public GameObject restartButton;
    public TextMeshPro timerText;
    private bool isRunning = true;
    public GameObject returnButton;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip timerEndClip;
    private bool hasPlayedEndSound = false;

    void Start()
    {
        currentTime = startTime;
        UpdateTimerDisplay();
        restartButton.SetActive(false);
        returnButton.SetActive(false);
        // Optional fallback
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            isRunning = false;
            OnTimerEnd();
        }

        UpdateTimerDisplay();
    }

    public void AddTime(float seconds)
    {
        currentTime += seconds;
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("Time: {0:0}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        Debug.Log("Game Over!");
        restartButton.SetActive(true);
        returnButton.SetActive(true);
        //  Play sound once
        if (!hasPlayedEndSound && audioSource != null && timerEndClip != null)
        {
            audioSource.PlayOneShot(timerEndClip);
            hasPlayedEndSound = true;
        }
        FindFirstObjectByType<HighScoreManager>().TryAddScore(FindFirstObjectByType<ScoreTracker>().score);

        // TODO: Disable ball grabbing or scoring here if needed
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
