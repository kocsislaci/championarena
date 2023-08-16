using UnityEngine;

namespace Interfaces
{
    public abstract class DamagerBehaviour: MonoBehaviour
    {
        protected abstract void Damage(DamageableBehaviour target);
    }
}
