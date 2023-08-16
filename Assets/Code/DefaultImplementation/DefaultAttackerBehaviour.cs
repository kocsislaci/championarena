using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultImplementation
{
    public class DefaultAttackerBehaviour: AttackerBehaviour
    {
        public override void InvokeCombatAction1(InputAction.CallbackContext context)
        {
            Debug.Log("Invoked Combat action 1");
        }
        public override void InvokeCombatAction2(InputAction.CallbackContext context)
        {
            Debug.Log("Invoked Combat action 2");
        }
    }
}