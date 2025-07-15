using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class HighScoreManager : MonoBehaviour
{
    public int maxScores = 5; // Top 5 scores
    public TextMeshPro scoreBoardText;

    private List<int> highScores = new List<int>();

    void Start()
    {
        LoadHighScores();
        UpdateScoreBoardText();
    }

    public void TryAddScore(int newScore)
    {
        highScores.Add(newScore);
        highScores = highScores.OrderByDescending(score => score).Take(maxScores).ToList();
        SaveHighScores();
        UpdateScoreBoardText();
    }

    void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore_" + i, highScores[i]);
        }
        PlayerPrefs.Save();
    }

    void LoadHighScores()
    {
        highScores.Clear();
        for (int i = 0; i < maxScores; i++)
        {
            if (PlayerPrefs.HasKey("HighScore_" + i))
                highScores.Add(PlayerPrefs.GetInt("HighScore_" + i));
        }
    }

    void UpdateScoreBoardText()
    {
        if (scoreBoardText == null) return;

        scoreBoardText.text = " High Scores:\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            scoreBoardText.text += $"{i + 1}. {highScores[i]}\n";
        }
    }
}
