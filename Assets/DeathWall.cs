using UnityEngine;
using UnityEditor;  // Only for the editor
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{
    // Use a string to store the scene name
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Load the scene using the scene name string
        SceneManager.LoadScene(sceneName);
    }
}
