using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Author: Re�at Kaan Hekimo�lu
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
