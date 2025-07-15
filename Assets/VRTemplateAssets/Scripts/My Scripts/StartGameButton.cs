using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string sceneToLoad = "BasicScene"; // Change to your actual scene name

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") )
        {
            Debug.Log("Button touched! Loading scene...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
