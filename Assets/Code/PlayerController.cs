using System;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(MovableBehaviour))]
[RequireComponent(typeof(AttackerBehaviour))]
public class PlayerController : MonoBehaviour
{
    public Color PlayerColor { get; private set; }

    private PlayerInput PlayerInput
    {
        get
        {
            if (_playerInput == null)
            {
                _playerInput = GetComponent<PlayerInput>();
            }
            return _playerInput;
        }
    }
    private PlayerInput _playerInput;

    private MovableBehaviour MovableBehaviour
    {
        get
        {
            if (_movableBehaviour == null)
            {
                _movableBehaviour = GetComponent<MovableBehaviour>();
            }
            return _movableBehaviour;
        }
    }
    private MovableBehaviour _movableBehaviour;

    private AttackerBehaviour AttackerBehaviour
    {
        get
        {
            if (_attackerBehaviour == null)
            {
                _attackerBehaviour = GetComponent<AttackerBehaviour>();
            }
            return _attackerBehaviour;
        }
    }
    private AttackerBehaviour _attackerBehaviour;

    private void OnEnable()
    {
        if (PlayerInput.actions != null) 
            PlayerInput.actions.Enable();
    }

    private void OnDisable()
    {
        if (PlayerInput.actions != null) 
            PlayerInput.actions.Disable();
    }

    public void Init(Color playerColor)
    {
        PlayerColor = playerColor;
        SetActionMap();
    }

    private void SetActionMap()
    {
        var scheme = "";
        if (PlayerColor == Color.red)
            scheme = "RedKeyboard";
        else if (PlayerColor == Color.blue)
            scheme = "BlueKeyboard";
        PlayerInput.SwitchCurrentControlScheme(scheme);
        PlayerInput.actions["Movement"].performed += MovableBehaviour.OnMovement;
        
        
        // PlayerInput.actions["CombatAction1"].performed += AttackerBehaviour.InvokeCombatAction1;
        // PlayerInput.actions["CombatAction2"].performed += AttackerBehaviour.InvokeCombatAction2;
    }
    // TODO: implement callback behaviour here
}
