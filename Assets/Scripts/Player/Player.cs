using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class Player : PlayerBase
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private PlayerAnimator _playerAnimator;

    public PlayerAnimator PlayerAnimator => _playerAnimator;

    private void Update()
    {
        _playerAnimator.SetTurn(_mouseInput.TurnValue);
    }

    public void StartMove()
    {
        _mouseInput.enabled = true;
        _movementSystem.enabled = true;
    }

    public void StopMove()
    {
        _mouseInput.enabled = false;
        _movementSystem.enabled = false;
    }
}