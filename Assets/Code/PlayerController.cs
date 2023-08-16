using System;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(DamageableBehaviour))]
[RequireComponent(typeof(MovableBehaviour))]
[RequireComponent(typeof(AttackerBehaviour))]
public class PlayerController : MonoBehaviour
{
    public Color PlayerColor { get; private set; }

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
    
    public void Init(Color playerColor, PlayerInput playerInput)
    {
        PlayerColor = playerColor;
        var colorString = "";
        if (playerColor == Color.red)
        {
            colorString = "Red";
        }
        else if (playerColor == Color.blue)
        {
            colorString = "Blue";
        }
        else
        {
            throw new Exception("Wrong color in playerController Init()");
        }
        playerInput.actions[colorString + "Movement"].started += MovableBehaviour.OnMovement;
        playerInput.actions[colorString + "Movement"].performed += MovableBehaviour.OnMovement;
        playerInput.actions[colorString + "Movement"].canceled += MovableBehaviour.OnMovement;
        playerInput.actions[colorString + "CombatAction1"].performed += AttackerBehaviour.InvokeCombatAction1;
        playerInput.actions[colorString + "CombatAction2"].performed += AttackerBehaviour.InvokeCombatAction2;
    }
}
