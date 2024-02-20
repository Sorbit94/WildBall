using UnityEngine;

public class FollowPartSyst : MonoBehaviour
{
    [SerializeField] private Transform player;
  

    void Update()
    {
        transform.position = player.position;
    }
}
