using UnityEngine;
using UnityEngine.Events;

namespace Interfaces
{
    public abstract class DamageableBehaviour: MonoBehaviour
    {
        protected const float MaxHealth = 100;
        
        public float CurrentHealth
        {
            get => _currentHealth;
            protected set
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
                Debug.Log($"Health: {value}");
                _currentHealth = value;
            }
        }
        [SerializeField] private float _currentHealth;
        public UnityEvent<PlayerController> die = new ();
        
        protected virtual void Awake()
        {
            CurrentHealth = MaxHealth;
            die.AddListener(OnDying);
        }

        protected abstract void OnDying(PlayerController self);
        public abstract void OnDamage(float damage);
    }
}
