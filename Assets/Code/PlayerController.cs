using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovableBehaviour))]
// [RequireComponent(typeof(DamageableBehaviour))]
// [RequireComponent(typeof(AttackerBehaviour))]
public class PlayerController : MonoBehaviour
{
    private MovableBehaviour _movableBehaviour;
    private PlayerInput _playerInput;
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movableBehaviour = GetComponent<MovableBehaviour>();

        _playerInput.actionEvents[0].AddListener(_movableBehaviour.OnMove);
    }
    
    // TODO: implement callback behaviour here
}
