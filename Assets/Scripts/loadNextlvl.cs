
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads Next level when Player enters collider
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class loadNextlvl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
