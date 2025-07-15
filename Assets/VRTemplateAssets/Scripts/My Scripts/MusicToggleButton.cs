using UnityEngine;

// Author: Reþat Kaan Hekimoðlu
// Date: July 2025
public class MusicToggleButton : MonoBehaviour
{
    public float cooldownTime = 1f;
    private bool isCooldown = false;

    public Color onColor = new Color(0f, 1f, 0.2f, 1f); // neon green
    public Color offColor = new Color(1f, 0f, 0f, 0.4f); // transparent red
    private Renderer buttonRenderer;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        UpdateButtonColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCooldown) return;

        if (other.CompareTag("PlayerHand") )
        {
            Debug.Log("Music toggle button touched!");

            if (MusicManager.Instance != null)
            {
                MusicManager.Instance.ToggleMusic();
                UpdateButtonColor();
                StartCoroutine(Cooldown());
            }
        }
    }

    private void UpdateButtonColor()
    {
        if (buttonRenderer == null || buttonRenderer.material == null) return;

        if (MusicManager.Instance != null && MusicManager.Instance.IsPlaying())
        {
            buttonRenderer.material.color = onColor;
        }
        else
        {
            buttonRenderer.material.color = offColor;
        }
    }

    private System.Collections.IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
