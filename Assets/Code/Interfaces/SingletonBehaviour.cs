using UnityEngine;

namespace Interfaces
{
    public abstract class SingletonBehaviour<T>: MonoBehaviour where T : SingletonBehaviour<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake() 
        {
            if (Instance != null && Instance != (T)this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = (T)this; 
            } 
        }
    }
}
