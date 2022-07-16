using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Stumbling = nameof(Stumbling);
    private const string ThrowStart = nameof(ThrowStart);
    private const string ThrowEnd = nameof(ThrowEnd);
    
    private const string Turn = nameof(Turn);

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private EndAnimationHandler _endAnimationHandler;
    [SerializeField] private float _turnSpeed = 30;
    [SerializeField] private float _sensitivity = 50000;

    private float _currentTurnValue;

    public event Action ThrowEnded;

    public void SetTurn(float value)
    {
        value = Mathf.Clamp(value * _sensitivity, -1, 1);
        _currentTurnValue = Mathf.MoveTowards(_currentTurnValue, value, _turnSpeed * Time.deltaTime);
        _playerAnimator.SetFloat(Turn, _currentTurnValue);
    }

    public void ShowIdle()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Idle);
    }

    public void ShowRun()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Run);
    }

    public void ShowStumbling()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Stumbling);
    }

    public void ShowThrowPrepare(Action ended)
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(ThrowStart);
        _endAnimationHandler.WaitingForThrowPrepare(ended);
    }

    public void ShowThrowEnd()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(ThrowEnd);
        _endAnimationHandler.WaitingForThrowEnded(()=> ThrowEnded?.Invoke());
    }

    private void ResetTriggers()
    {
        _playerAnimator.ResetTrigger(Idle);
        _playerAnimator.ResetTrigger(Run);
        _playerAnimator.ResetTrigger(Stumbling);
        _playerAnimator.ResetTrigger(ThrowStart);
        _playerAnimator.ResetTrigger(ThrowEnd);
    }
}