using System;
using RunnerMovementSystem;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossAnimator _bossAnimator;
    [SerializeField] private BossHittedView bossHittedView;
    [SerializeField] private BossInput _bossInput;
    [SerializeField] private MovementSystem _movementSystem;

    private float _defaultSpeed;

    public BossAnimator BossAnimator => _bossAnimator;
    public BossHittedView BossHittedView => bossHittedView;

    private void Awake()
    {
        _defaultSpeed = _movementSystem.DefaultSpeed;
    }

    private void OnEnable()
    {
        _movementSystem.RoadEndReached += OnRoadEndReached;
    }

    private void OnDisable()
    {
        _movementSystem.RoadEndReached -= OnRoadEndReached;
    }

    public void StarMove()
    {
        _bossInput.Enable();
    }

    public void StopMove()
    {
        _bossInput.Disable();
    }

    public void SetTimeScale(float value)
    {
        _movementSystem.SetSpeed(_defaultSpeed * value);
        _bossAnimator.SetTimeScale(value);
    }

    private void OnRoadEndReached()
    {
        StopMove();
        _bossAnimator.ShowFinisher();
    }
}