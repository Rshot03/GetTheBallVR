using UnityEngine;

public class BounceDetector : MonoBehaviour
{
    // Author: Re�at Kaan Hekimo�lu
    // Date: July 2025
    public AudioClip bounceSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Optional fallback
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on BallBounceSound!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (audioSource != null && bounceSound != null)
            {
                audioSource.PlayOneShot(bounceSound);
            }
        }
    }
}