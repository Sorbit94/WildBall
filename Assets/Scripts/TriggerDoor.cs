using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            animator = other.GetComponent<Animator>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            animator = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInTrigger)
        {
            if (animator)
            {
                animator.SetTrigger("OpenDoor");
            }
            else
            {
                animator = GetComponent<Animator>();
                animator?.SetTrigger("OpenDoor");
            }
        }
    }
}
