using System.Collections;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    [SerializeField] private float speed;

    private bool transportingPlayer = false;
    private GameObject player;

    private void Start()
    {
        transform.position = startPoint;
    }

    private void Update()
    {
        if (transportingPlayer)
        {
            player.transform.position = transform.position;

            if (transform.position == endPoint)
            {
                transportingPlayer = false;
                player.transform.parent = null;
                transform.position = startPoint;
                player.transform.localPosition = endPoint;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !transportingPlayer)
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = new Vector3(0, -0.1f, 0);

            transportingPlayer = true;
            player = other.gameObject;

            StartCoroutine(MoveDragon());
        }
    }

    private IEnumerator MoveDragon()
    {
        float journeyLength = Vector3.Distance(startPoint, endPoint);
        float journeyTime = journeyLength / speed;

        float startTime = Time.time;

        while (transform.position != endPoint)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfJourney);

            yield return null;
        }
    }
}
