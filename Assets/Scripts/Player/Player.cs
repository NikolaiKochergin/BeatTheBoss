using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public sealed class Player : PlayerBase
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private ThrowInput _throwInput;

    private float _defaultSpeed;
    
    public ThrowInput ThrowInput => _throwInput;

    protected override void Awake()
    {
        base.Awake();
        _defaultSpeed = _movementSystem.DefaultSpeed;
    }

    private void Update()
    {
        PlayerAnimator.SetTurn(_mouseInput.TurnValue);
    }

    public void SetTimeScale(float value)
    {
        _movementSystem.SetSpeed(_defaultSpeed * value);
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