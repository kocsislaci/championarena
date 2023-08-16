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
        private float _moving;
        private float _turning;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponentInParent<Rigidbody>();
        }
        
        private void Update()
        {
            Moving();
        }

        public override void OnMovement(InputAction.CallbackContext context)
        {
            base.OnMovement(context);
            _moving = CurrentMovement.y;
            _turning = CurrentMovement.x;        
        }
        
        private void Moving()
        {
            float velocity = _moving * speed;
            Vector3 facing = transform.forward;
            facing.Scale(new Vector3(velocity, velocity, velocity));
            _rigidbody.velocity = facing;
            _rigidbody.angularVelocity = new Vector3(0, _turning * speed, 0);    
        }
    }
}
