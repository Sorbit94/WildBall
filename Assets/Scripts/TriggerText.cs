using UnityEngine;

public class TriggerText : MonoBehaviour
{
    [SerializeField] private GameObject textObj;

    private void Start()
    {
        textObj.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textObj.SetActive(false);
        }
    }
}
