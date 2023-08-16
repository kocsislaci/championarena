using System.Collections;
using Interfaces;
using UnityEngine;

namespace DefaultImplementation
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class StoneDamagerBehaviour: DamagerBehaviour
    {
        [SerializeField] private float damagePower = 10f;
        [SerializeField] private float velocity = 4f;
        [SerializeField] private float lifeSpan = 10f;

        private void Awake()
        {
            StartCoroutine(LifeSpan());
        }
        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.layer);
            if (other.gameObject.layer == LayerMask.NameToLayer("Damageable"))
            {
                Debug.Log(other.gameObject.GetComponentInParent<DamageableBehaviour>());
                Damage(other.gameObject.GetComponentInParent<DamageableBehaviour>());
            }
        }

        public void Throw(Vector3 direction)
        {
            GetComponent<Rigidbody>().velocity = direction * velocity;
        }
        
        protected override void Damage(DamageableBehaviour target)
        {
            target.OnDamage(damagePower);
        }

        private IEnumerator LifeSpan()
        {
            yield return new WaitForSeconds(lifeSpan);
            Destroy(gameObject);
        }
    }
}
