using Interfaces;

namespace DefaultImplementation
{
    public class DefaultDamageableBehaviour: DamageableBehaviour
    {
        protected override void OnDying(PlayerController self)
        {
            Destroy(gameObject);
        }

        public override void OnDamage(float damage)
        {
            CurrentHealth -= damage;
        }
    }
}