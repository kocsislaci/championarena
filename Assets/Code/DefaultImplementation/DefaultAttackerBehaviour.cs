using Interfaces;
using UnityEngine;

namespace DefaultImplementation
{
    public class DefaultAttackerBehaviour: AttackerBehaviour
    {
        public override void CombatAction1()
        {
            Debug.Log("Invoked Combat action 1");
        }
        public override void CombatAction2()
        {
            Debug.Log("Invoked Combat action 2");
        }
    }
}