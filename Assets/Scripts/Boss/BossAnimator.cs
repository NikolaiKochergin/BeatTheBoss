using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    
    [SerializeField] private Animator _bossAnimator;

    public void ShowIdle()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Idle);
    }

    public void ShowRun()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Run);
    }

    private void ResetTriggers()
    {
        _bossAnimator.ResetTrigger(Idle);
        _bossAnimator.ResetTrigger(Run);
    }
}