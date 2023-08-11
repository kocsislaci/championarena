using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultImplementation
{
    public sealed class RaceCarMovement: MovableBehaviour
    {
        // TODO: Introduce fine tuning variables
        [SerializeField]
        private float speed = 10;
        private float moving;
        private float turning;
        private Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = GetComponentInParent<Rigidbody>();
        }
        
        private void Update()
        {
            Moving();
        }

        public override void OnMove(InputAction.CallbackContext context)
        {
            base.OnMove(context);
            moving = CurrentMovement.y;
            turning = CurrentMovement.x;        
        }
        
        private void Moving()
        {
            float velocity = moving * speed;
            Vector3 facing = transform.forward;
            facing.Scale(new Vector3(velocity, velocity, velocity));
            rigidbody.velocity = facing;
            rigidbody.angularVelocity = new Vector3(0, turning * speed, 0);    
        }
    }
}
