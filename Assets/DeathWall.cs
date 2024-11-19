using UnityEngine;
using UnityEditor;  
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{
    public SceneAsset scene;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string sceneName = scene.name;
        SceneManager.LoadScene(sceneName);

    }

}
