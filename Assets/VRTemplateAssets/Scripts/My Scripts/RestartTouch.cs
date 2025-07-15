using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTouch : MonoBehaviour
{
    // Author: Reþat Kaan Hekimoðlu
    // Date: July 2025

    private float lastTouchTime = 0f;
    public float cooldown = 1f; // prevent double-triggering

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time - lastTouchTime < cooldown) return;

        if (other.CompareTag("PlayerHand") )
        {
            Debug.Log("Restart button touched by: " + other.name);
            lastTouchTime = Time.time;
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
