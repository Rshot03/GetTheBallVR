using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTouch : MonoBehaviour
{
    // Author: Reþat Kaan Hekimoðlu
    // Date: July 2025
    public string sceneToLoad = "SampleScene"; // Change to your actual scene name

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            Debug.Log("Button touched! Loading scene...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
