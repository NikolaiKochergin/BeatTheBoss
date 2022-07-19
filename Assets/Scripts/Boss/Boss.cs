using System;
using RunnerMovementSystem;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossAnimator _bossAnimator;
    [SerializeField] private BossHittedView _bossHittedView;
    [SerializeField] private BossInput _bossInput;
    [SerializeField] private MovementSystem _movementSystem;

    public BossAnimator BossAnimator => _bossAnimator;
    public BossHittedView BossHittedView => _bossHittedView;

    private float _defaultSpeed = 10;

    public void StarMove()
    {
        _bossInput.Enable();
    }

    public void StopMove()
    {
        _bossInput.Disable();
    }

    public void SetSpeedScale(float value)
    {
        _movementSystem.SetSpeed(_defaultSpeed * value);
    }
}