using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private PlayerMovement playerMovement;


        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(horizontal, 0, vertical).normalized;
            movement = Camera.main.transform.TransformDirection(new Vector3(horizontal, 0, vertical)).normalized;
            movement.y = 0;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }
    }
}
