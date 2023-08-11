using UnityEngine;

namespace Interfaces
{
    public abstract class DamageableBehaviour: MonoBehaviour
    {
        public int CurrentHealth{ get; set; }
        public int MaxHealth { get; set; }

        // public void onDamage(float damage);
    }
}
