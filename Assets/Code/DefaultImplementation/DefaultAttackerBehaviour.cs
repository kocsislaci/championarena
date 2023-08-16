using Interfaces;
using UnityEngine;

namespace DefaultImplementation
{
    public class DefaultAttackerBehaviour: AttackerBehaviour
    {
        [SerializeField] private GameObject throwableStonePrefab;
        
        public override void CombatAction1()
        {
            var stone = Instantiate(throwableStonePrefab, transform.position + new Vector3(0f, 1f, 1f),
                Quaternion.identity);
            stone.GetComponent<StoneDamagerBehaviour>().Throw(transform.forward);
        }
        public override void CombatAction2()
        {
            Debug.Log("Invoked Combat action 2");
        }
    }
}