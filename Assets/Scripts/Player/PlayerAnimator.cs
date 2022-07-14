using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    
    [SerializeField] private Animator _playerAnimator;

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