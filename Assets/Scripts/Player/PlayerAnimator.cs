using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Turn = nameof(Turn);

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float _turnSpeed = 30;
    [SerializeField] private float _sensitivity = 50000;

    private float _currentTurnValue;

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

    private void ResetTriggers()
    {
        _playerAnimator.ResetTrigger(Idle);
        _playerAnimator.ResetTrigger(Run);
    }
}