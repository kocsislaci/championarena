using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interfaces
{
    public abstract class AttackerBehaviour: MonoBehaviour
    {
        private float _cooldownDuration1 = 1f;
        private float _cooldownDuration2 = .5f;
        private bool _isCooldown1 = false;
        private bool _isCooldown2 = false;
        
        IEnumerator StartCooldown1()
        {
            _isCooldown1 = true;
            yield return new WaitForSeconds(_cooldownDuration1);
            _isCooldown1 = false;
        }
        
        IEnumerator StartCooldown2()
        {
            _isCooldown2 = true;
            yield return new WaitForSeconds(_cooldownDuration2);
            _isCooldown2 = false;
        }

        public void InvokeCombatAction1(InputAction.CallbackContext context)
        {
            if (!_isCooldown1)
            {
                StartCoroutine(StartCooldown1());
                CombatAction1();
            }
        }

        public abstract void CombatAction1();

        public void InvokeCombatAction2(InputAction.CallbackContext context)
        {
            if (!_isCooldown2)
            {
                StartCoroutine(StartCooldown2());
                CombatAction2();
            }
        }
        public abstract void CombatAction2();

    }
}
