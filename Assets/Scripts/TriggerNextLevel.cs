using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
