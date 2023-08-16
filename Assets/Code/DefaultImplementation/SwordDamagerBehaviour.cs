using Interfaces;
using UnityEngine;

namespace DefaultImplementation
{
    public class SwordDamagerBehaviour: DamagerBehaviour
    {
        [SerializeField] private float damagePower = 5f;
        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.layer);
            if (other.gameObject.layer == LayerMask.NameToLayer("Damageable"))
            {
                Damage(other.gameObject.GetComponentInParent<DamageableBehaviour>());
            }
        }

        protected override void Damage(DamageableBehaviour target)
        {
            target.OnDamage(damagePower);
        }
    }
}
