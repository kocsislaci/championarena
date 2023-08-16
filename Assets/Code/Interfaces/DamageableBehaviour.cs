using UnityEngine;
using UnityEngine.Events;

namespace Interfaces
{
    public abstract class DamageableBehaviour: MonoBehaviour
    {
        protected const int MaxHealth = 100;
        
        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                switch (value)
                {
                    case <= 0:
                        die.Invoke(GetComponent<PlayerController>());
                        break;
                    case > MaxHealth:
                        _currentHealth = MaxHealth;
                        break;
                }
                _currentHealth = value;
            }
            
        }
        private int _currentHealth;
        public UnityEvent<PlayerController> die = new ();
        
        protected virtual void Awake()
        {
            CurrentHealth = MaxHealth;
            die.AddListener(OnDying);
        }

        protected abstract void OnDying(PlayerController self);
        public abstract void OnDamage(DamagerBehaviour damager);
    }
}
