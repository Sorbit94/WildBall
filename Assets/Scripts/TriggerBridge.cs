using UnityEngine;

public class TriggerBridge : MonoBehaviour
{
    [SerializeField] private GameObject Obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Obj.GetComponent<Animation>().Play("FloorUp");
        }
    }
}
