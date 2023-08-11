using UnityEngine;
using UnityEngine.InputSystem;

namespace Interfaces
{
    public abstract class MovableBehaviour: MonoBehaviour
    {
        protected Vector2 CurrentMovement;
        
        public virtual void OnMove(InputAction.CallbackContext context)
        {
            CurrentMovement = context.ReadValue<Vector2>();
        }
    }
}
