using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Make sure only one MusicManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist between scenes
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMusic()
    {
        if (audioSource == null) return;

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }

    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
}
