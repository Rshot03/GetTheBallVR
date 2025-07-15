using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreTracker : MonoBehaviour
{
    // Author: Reþat Kaan Hekimoðlu
    // Date: July 2025
    public int score = 0;
    public TextMeshPro scoreText;
    public AudioSource audioSource;

    [Header("References")]
    public RandomMovement ballMovement;   // Link this in Inspector
    public GameTimer gameTimer;           // Link this in Inspector

    [System.Serializable]
    public class MilestoneEffect
    {
        public int milestone;
        public AudioClip clip;
        public float speedMultiplier = 1.2f;
        public float timeBonus = 10f;
    }

    public List<MilestoneEffect> milestoneSounds = new List<MilestoneEffect>();
    private HashSet<int> triggeredMilestones = new HashSet<int>();

    public void AddPoint()
    {
        score++;
        Debug.Log("Score is now: " + score);

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        foreach (var milestoneEffect in milestoneSounds)
        {
            if (score == milestoneEffect.milestone && !triggeredMilestones.Contains(score))
            {
                triggeredMilestones.Add(score);

                //  Play sound
                if (audioSource != null && milestoneEffect.clip != null)
                    audioSource.PlayOneShot(milestoneEffect.clip);

                //  Increase ball speed
                if (ballMovement != null)
                    ballMovement.IncreaseSpeed(milestoneEffect.speedMultiplier);

                //  Add bonus time
                if (gameTimer != null)
                    gameTimer.AddTime(milestoneEffect.timeBonus);

                break;
            }
        }
    }

    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: 0";
        else
            Debug.LogWarning("Score text reference is null!");

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
}
