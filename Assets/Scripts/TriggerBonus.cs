using UnityEngine;

public class TriggerBonus : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioSource bonusSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleSystem.Play();
            bonusSound.Play();

            Destroy(gameObject);
        }
    }
}
