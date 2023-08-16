using UnityEngine;
using UnityEngine.InputSystem;

namespace Interfaces
{
    public abstract class AttackerBehaviour: MonoBehaviour
    {
        // TODO cooldown
        // TODO cooldown counter coroutines


        public abstract void InvokeCombatAction1(InputAction.CallbackContext context);

        public abstract void InvokeCombatAction2(InputAction.CallbackContext context);
    }
}
