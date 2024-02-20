using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private AudioSource deathSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObject.GetComponent<MeshRenderer>().enabled = false;
            deathParticles.Play();
            deathSound.Play();
            StartCoroutine(ReloadLevel());
        }
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
