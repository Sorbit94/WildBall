using UnityEngine;

public class TriggerBridgeLvl3 : MonoBehaviour
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
                animator.SetTrigger("LowerBridge");
            }
            else
            {
                animator = GetComponent<Animator>();
                animator?.SetTrigger("LowerBridge");
            }
        }
    }
}
