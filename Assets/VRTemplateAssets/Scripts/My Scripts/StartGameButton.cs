using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Author: Reþat Kaan Hekimoðlu
    // Date: July 2025

    public string sceneToLoad = "BasicScene"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") )
        {
            Debug.Log("Button touched! Loading scene...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
