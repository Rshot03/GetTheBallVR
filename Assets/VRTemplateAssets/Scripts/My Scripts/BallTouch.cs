using UnityEngine;

public class BallTouch : MonoBehaviour
{
    // Author: Reþat Kaan Hekimoðlu
    // Date: July 2025
    public ScoreTracker tracker;
    public GameTimer timer;
    public AudioClip touchSound;

    private AudioSource audioSource;
    private float lastTouchTime = 0f;
    public float touchCooldown = 0.5f;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer != null && !timer.IsRunning()) return;

        if (Time.time - lastTouchTime > touchCooldown &&
            (other.CompareTag("PlayerHand") ))
        {
            lastTouchTime = Time.time;
            tracker.AddPoint();

            if (audioSource != null && touchSound != null)
                audioSource.PlayOneShot(touchSound);
        }
    }
}
