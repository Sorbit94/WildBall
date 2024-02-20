using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    [SerializeField] private ParticleSystem winParticleSystem;
    [SerializeField] private ParticleSystem win1ParticleSystem;
    [SerializeField] private AudioSource winSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winParticleSystem.Play();
            win1ParticleSystem.Play();
            winSound.Play();

        }
    }
}
