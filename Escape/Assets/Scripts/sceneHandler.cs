using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnClick : MonoBehaviour
{
    //!Name of the scene you want to load
    [SerializeField] private string sceneName;

    //!Called when the GameObject this script is attached to is clicked
    void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name not specified.");
        }
    }
}
